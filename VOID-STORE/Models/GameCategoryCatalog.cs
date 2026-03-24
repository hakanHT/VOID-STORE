using System;
using System.Collections.Generic;
using System.Linq;

namespace VOID_STORE.Models
{
    public static class GameCategoryCatalog
    {
        // kullanilan oyun kategorileri
        public static IReadOnlyList<string> All { get; } = new List<string>
        {
            "Aksiyon",
            "Macera",
            "MMORPG",
            "FPS",
            "RPG",
            "Strateji",
            "Korku",
            "Yarış",
            "Spor",
            "Simülasyon"
        };

        // varsayilan kategori adi
        public static string Default => All[0];

        public static string Normalize(string? value)
        {
        // secimi gecerli kategoriye uyarla
            if (string.IsNullOrWhiteSpace(value))
            {
                return Default;
            }

            string normalizedValue = value.Trim();
            string? matchedValue = All.FirstOrDefault(
                category => category.Equals(normalizedValue, StringComparison.OrdinalIgnoreCase));

            return matchedValue ?? Default;
        }
    }
}
