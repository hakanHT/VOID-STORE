using System.Windows.Media.Imaging;

namespace VOID_STORE.Models
{
    public class WishlistGameItem
    {
        // istek listesindeki oyunu tanimlar
        public int GameId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        // fiyat ve eklenme metnini tutar
        public decimal PriceAmount { get; set; }

        public string PriceText { get; set; } = string.Empty;

        public string AddedAtText { get; set; } = string.Empty;

        public string CoverImagePath { get; set; } = string.Empty;

        // listede gosterilen kapak gorselini tutar
        public BitmapImage? CoverPreview { get; set; }
    }
}
