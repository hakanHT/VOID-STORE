using System;
using System.Collections.Generic;
using System.Linq;

namespace VOID_STORE.Models
{
    public static class GameCategoryCatalog
    {
        // kullanılan kategori listesi
        public static IReadOnlyList<string> All { get; } = new List<string>
        {
            "Aksiyon",
            "Macera",
            "RPG",
            "MMORPG",
            "FPS",
            "Strateji",
            "Korku",
            "Bağımsız",
            "Hayatta Kalma",
            "Açık Dünya",
            "Roguelike",
            "Platform",
            "Simülasyon",
            "Spor",
            "Yarış",
            "Bulmaca",
            "Çok Oyunculu",
            "Oynaması Ücretsiz"
        };

        // varsayılan kategori
        public static string Default => All[0];

        public static string Normalize(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Default;
            }

            // Virgül veya pipe ile ayrılmış birden fazla kategoriyi destekle
            var parts = value.Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var normalizedParts = new List<string>();

            foreach (var part in parts)
            {
                string? matchedValue = All.FirstOrDefault(
                    category => category.Equals(part, StringComparison.OrdinalIgnoreCase));
                
                // Katalogda varsa düzgün halini al, yoksa olduğu gibi koru (eski veriler için)
                normalizedParts.Add(matchedValue ?? part);
            }

            if (normalizedParts.Count == 0)
            {
                return Default;
            }

            return string.Join(", ", normalizedParts);
        }
    }
}
