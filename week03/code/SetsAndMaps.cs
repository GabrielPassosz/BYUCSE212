using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();
        var used = new HashSet<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;

            var reversed = $"{word[1]}{word[0]}";

            if (wordSet.Contains(reversed) && !used.Contains(word) && !used.Contains(reversed))
            {
                pairs.Add($"{word} & {reversed}");
                used.Add(word);
                used.Add(reversed);
            }
        }

        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var letterCounts = new Dictionary<char, int>();

        foreach (var letter in word1)
        {
            if (letterCounts.ContainsKey(letter))
                letterCounts[letter]++;
            else
                letterCounts[letter] = 1;
        }

        foreach (var letter in word2)
        {
            if (!letterCounts.ContainsKey(letter))
                return false;

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
                return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
            return Array.Empty<string>();

        var summaries = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties?.Place ?? "Unknown location";
            var magnitude = feature.Properties?.Mag?.ToString() ?? "unknown";
            summaries.Add($"{place} - Mag {magnitude}");
        }

        return summaries.ToArray();
    }
}