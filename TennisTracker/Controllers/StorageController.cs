using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TennisTracker.Models;

namespace TennisTracker.Controllers
{
    public static class StorageController
    {
        private static readonly string FilePath = "matches.json";

        public static void SaveMatches(List<MatchItem> matches)
        {
            var json = JsonSerializer.Serialize(matches, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static List<MatchItem> LoadMatches()
        {
            if (!File.Exists(FilePath))
                return new List<MatchItem>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<MatchItem>>(json) ?? new List<MatchItem>();
        }
    }
}