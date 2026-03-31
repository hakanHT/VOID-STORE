using System.Windows.Media.Imaging;

namespace VOID_STORE.Models
{
    public class ProfileShowcaseItem
    {
        // vitrindeki slot sirasini tutar
        public int SlotIndex { get; set; }

        public int GameId { get; set; }

        // vitrin kartinda gosterilen metni tasir
        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string CoverImagePath { get; set; } = string.Empty;

        // kartta kullanilan kapak gorselini tasir
        public BitmapImage? CoverPreview { get; set; }

        public bool IsEmpty { get; set; }

        public string PlaceholderText { get; set; } = string.Empty;
    }
}
