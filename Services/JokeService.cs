using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeFetcher.Services
{
    public class JokeService
    {
        private readonly HttpClient _client;

        public JokeService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "CSharp-Joke-App");
        }

        public async Task<string> GetRandomJokeAsync()
        {
            string url = "https://v2.jokeapi.dev/joke/Any";

            var response = await _client.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(response);

            var root = doc.RootElement;

            string type = root.GetProperty("type").GetString();

            if (type == "single")
            {
                return root.GetProperty("joke").GetString();
            }
            else
            {
                return root.GetProperty("setup").GetString()
                    + "\n"
                    + root.GetProperty("delivery").GetString();
            }
        }
    }
}