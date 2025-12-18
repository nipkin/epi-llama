namespace epiv12demo.Business.Services
{
    using System.Text.Json;

    public class LocalActivityAnalyzer(string prompt)
    {
        private readonly string _prompt = prompt;

        public async Task<string> EstimateActivityLevelAsync(string description)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://localhost:11434/") };

            var requestBody = new
            {
                //model = "ALIENTELLIGENCE/personalizednutrition:latest",
                model = "mistral",
                prompt = _prompt,
                temperature = 0
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "api/generate")
            {
                Content = JsonContent.Create(requestBody)
            };

            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var fullText = string.Empty;

            using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);

            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                using var doc = JsonDocument.Parse(line);
                var chunk = doc.RootElement.GetProperty("response").GetString();
                fullText += chunk;
            }

            return fullText.Trim().ToLower();
        }
    }
}