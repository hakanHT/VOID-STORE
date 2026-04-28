using System.Windows.Media.Imaging;

namespace VOID_STORE.Models
{
    public class StoreGameCardItem
    {
        public int GameId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Subtitle { get; set; } = string.Empty;

        public string PriceText { get; set; } = string.Empty;

        public decimal PriceAmount { get; set; }

        public string CoverImagePath { get; set; } = string.Empty;

        public BitmapImage? CoverPreview { get; set; }

        public bool IsOwned { get; set; }

        public bool IsInCart { get; set; }

        public string StatusText { get; set; } = string.Empty;
        public bool IsReleased { get; set; }
        public bool IsOnDiscount { get; set; }
        public int DiscountRate { get; set; }
    }
}
