using System;
using System.Data;
using SqlParameter = MySql.Data.MySqlClient.MySqlParameter;
using VOID_STORE.Models;

namespace VOID_STORE.Controllers
{
    public class LoginController
    {
        public LoginController()
        {
            // controller acilisini hafif tut
        }

        // girilen bilgilerin veritabaninda eslesip eslesmedigini kontrol et
        public bool ValidateUser(string usernameOrEmail, string password, out bool isEmailVerified, out bool isAdmin)
        {
            isEmailVerified = false;
            isAdmin = false;

            try
            {
                // oturum kolonlarini sorgudan once hazirla
                UserCommerceSchemaManager.EnsureUserSessionSchema();

                // sifreyi dogrulama icin hashle
                string hashedPassword = SecurityManager.HashPassword(password);

                // kullanici profilini veritabanindan cek
                string loginQuery = "SELECT UserId, IsAdmin, IsEmailVerified FROM Users WHERE (Username = @User OR Email = @User) AND PasswordHash = @Password";
                SqlParameter[] loginParams =
                {
                    new SqlParameter("@User", usernameOrEmail),
                    new SqlParameter("@Password", hashedPassword)
                };

                DataTable dt = DatabaseManager.ExecuteQuery(loginQuery, loginParams);

                if (dt.Rows.Count > 0)
                {
                    isEmailVerified = Convert.ToBoolean(dt.Rows[0]["IsEmailVerified"]);
                    isAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public string GetDisplayUsername(string usernameOrEmail)
        {
            // oturum kolonlarini sorgudan once hazirla
            UserCommerceSchemaManager.EnsureUserSessionSchema();

            // oturumda gosterilecek kullanici adini getir
            object? result = DatabaseManager.ExecuteScalar(
                @"SELECT Username
                  FROM Users
                  WHERE Username = @User OR Email = @User
                  LIMIT 1;",
                new SqlParameter("@User", usernameOrEmail));

            return result?.ToString() ?? usernameOrEmail.Trim();
        }

        public AuthenticatedUserInfo GetAuthenticatedUser(string usernameOrEmail)
        {
            // oturum kolonlarini sorgudan once hazirla
            UserCommerceSchemaManager.EnsureUserSessionSchema();

            // oturum icin gereken alanlari getir
            DataTable table = DatabaseManager.ExecuteQuery(
                @"SELECT
                    UserId,
                    Username,
                    Balance,
                    COALESCE(ProfileImagePath, '') AS ProfileImagePath,
                    COALESCE(BannerImagePath, '') AS BannerImagePath,
                    COALESCE(Bio, '') AS Bio
                  FROM Users
                  WHERE Username = @User OR Email = @User
                  LIMIT 1;",
                new SqlParameter("@User", usernameOrEmail));

            if (table.Rows.Count == 0)
            {
                throw new InvalidOperationException("Kullanıcı bilgisi alınamadı.");
            }

            DataRow row = table.Rows[0];

            return new AuthenticatedUserInfo
            {
                UserId = Convert.ToInt32(row["UserId"]),
                Username = row["Username"]?.ToString() ?? "Oyuncu",
                Balance = row["Balance"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Balance"]),
                ProfileImagePath = row["ProfileImagePath"]?.ToString() ?? string.Empty,
                BannerImagePath = row["BannerImagePath"]?.ToString() ?? string.Empty,
                Bio = row["Bio"]?.ToString() ?? string.Empty
            };
        }
    }
}
