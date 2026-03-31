using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using SqlParameter = MySql.Data.MySqlClient.MySqlParameter;
using VOID_STORE.Models;

namespace VOID_STORE.Controllers
{
    public class WishlistController
    {
        public WishlistController()
        {
            // controller acilisini hafif tut
        }

        public HashSet<int> GetWishlistGameIds(int userId)
        {
            // misafir kullanicida bos liste don
            if (userId <= 0)
            {
                return new HashSet<int>();
            }

            // satin alinmis oyunlari listeye katma
            DataTable table = DatabaseManager.ExecuteQuery(
                @"SELECT wi.GameId
                  FROM WishlistItems wi
                  LEFT JOIN UserLibrary ul
                    ON ul.UserId = wi.UserId
                   AND ul.GameId = wi.GameId
                  WHERE wi.UserId = @UserId
                    AND ul.GameId IS NULL;",
                new SqlParameter("@UserId", userId));

            return table.Rows
                .Cast<DataRow>()
                .Select(row => Convert.ToInt32(row["GameId"], CultureInfo.InvariantCulture))
                .ToHashSet();
        }

        public IReadOnlyList<WishlistGameItem> GetWishlistItems(int userId)
        {
            // giris yoksa bos istek listesi don
            if (userId <= 0)
            {
                return new List<WishlistGameItem>();
            }

            // yayinda olan ve satin alinmamis oyunlari getir
            DataTable table = DatabaseManager.ExecuteQuery(
                @"SELECT
                    g.GameId,
                    g.Title,
                    g.Category,
                    g.Price,
                    g.CoverImagePath,
                    wi.CreatedAt
                  FROM WishlistItems wi
                  INNER JOIN Games g ON g.GameId = wi.GameId
                  LEFT JOIN UserLibrary ul
                    ON ul.UserId = wi.UserId
                   AND ul.GameId = wi.GameId
                  WHERE wi.UserId = @UserId
                    AND ul.GameId IS NULL
                    AND g.ApprovalStatus = 'approved'
                    AND g.IsActive = 1
                  ORDER BY wi.CreatedAt DESC, wi.WishlistItemId DESC;",
                new SqlParameter("@UserId", userId));

            List<WishlistGameItem> items = new();

            foreach (DataRow row in table.Rows)
            {
                // kartta gosterilecek alanlari modele cevir
                string coverPath = row["CoverImagePath"] == DBNull.Value
                    ? string.Empty
                    : row["CoverImagePath"]?.ToString() ?? string.Empty;
                decimal price = Convert.ToDecimal(row["Price"], CultureInfo.InvariantCulture);
                DateTime createdAt = Convert.ToDateTime(row["CreatedAt"], CultureInfo.InvariantCulture);

                items.Add(new WishlistGameItem
                {
                    GameId = Convert.ToInt32(row["GameId"], CultureInfo.InvariantCulture),
                    Title = row["Title"]?.ToString() ?? string.Empty,
                    Category = GameCategoryCatalog.Normalize(row["Category"]?.ToString()),
                    PriceAmount = price,
                    PriceText = $"₺{price:0.##}",
                    AddedAtText = createdAt.ToString("dd.MM.yyyy"),
                    CoverImagePath = coverPath,
                    CoverPreview = GameAssetManager.LoadBitmap(coverPath)
                });
            }

            return items;
        }

        public bool ToggleWishlist(int userId, int gameId)
        {
            // istek listesi icin oturum zorunlu
            if (userId <= 0)
            {
                throw new InvalidOperationException("İstek listesi için giriş yapmanız gerekiyor");
            }

            // sahip olunan oyun listede tutulmasin
            if (GameOwned(userId, gameId))
            {
                RemoveFromWishlist(userId, gameId);
                return false;
            }

            // varsa cikar yoksa ekle
            bool exists = GetWishlistGameIds(userId).Contains(gameId);
            if (exists)
            {
                RemoveFromWishlist(userId, gameId);
                return false;
            }

            DatabaseManager.ExecuteNonQuery(
                @"INSERT INTO WishlistItems (UserId, GameId)
                  VALUES (@UserId, @GameId);",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@GameId", gameId));

            return true;
        }

        public void RemoveFromWishlist(int userId, int gameId)
        {
            // gecersiz kullanicida islem yapma
            if (userId <= 0)
            {
                return;
            }

            // tek oyunu listeden sil
            DatabaseManager.ExecuteNonQuery(
                @"DELETE FROM WishlistItems
                  WHERE UserId = @UserId
                    AND GameId = @GameId;",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@GameId", gameId));
        }

        private bool GameOwned(int userId, int gameId)
        {
            // oyunun kutuphanede olup olmadigini kontrol et
            object? result = DatabaseManager.ExecuteScalar(
                @"SELECT COUNT(*)
                  FROM UserLibrary
                  WHERE UserId = @UserId
                    AND GameId = @GameId;",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@GameId", gameId));

            return result != null && Convert.ToInt32(result, CultureInfo.InvariantCulture) > 0;
        }
    }
}
