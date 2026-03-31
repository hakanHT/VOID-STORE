namespace VOID_STORE.Models
{
    public class ProfileOwnedGameOptionItem
    {
        // secilebilir oyunu tanimlar
        public int GameId { get; set; }

        public string Title { get; set; } = string.Empty;

        // secim kutusunda gosterilen metni tutar
        public string DisplayText { get; set; } = string.Empty;
    }
}
