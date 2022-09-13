using Newtonsoft.Json.Linq;

namespace champion_terminal
{
    internal class ValidationService
    {
        private static string ChampionsUrl => "https://ddragon.leagueoflegends.com/cdn/12.17.1/data/en_US/champion.json";

        private static readonly HttpClient Client = new();

        public ValidationService() { }

        public async Task<bool> Validate(string input)
        {
            var champions = await GetAllChampions();
            var match = champions.FirstOrDefault(str => str.Contains(input));

            if (match == null)
            {
                return false;
            }

            return true;
        }

        private static async Task<List<string>> GetAllChampions()
        {
            var response = await Client.GetAsync(ChampionsUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            var championsData = JObject.Parse(responseBody);
            var championsToken = championsData?.SelectToken("data");
            var champions = new List<string>();

            if (championsToken == null)
            {
                return champions;
            }

            foreach (var champion in championsToken)
            {
                champions.Add(champion?.First()?.SelectToken("id")?.ToString() ?? string.Empty);
            }

            return champions;
        }
    }
}
