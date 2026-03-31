using System.Windows.Media.Imaging;

namespace VOID_STORE.Models
{
    public class ProfileRecentPlayItem
    {
        // etkinlik akisindaki oyunu tanimlar
        public int GameId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        // oynama ve son giris metnini tasir
        public string PlayTimeText { get; set; } = string.Empty;

        public string LastPlayedText { get; set; } = string.Empty;

        public string CoverImagePath { get; set; } = string.Empty;

        // kartta gosterilen kapak onizlemesini tutar
        public BitmapImage? CoverPreview { get; set; }
    }
}
