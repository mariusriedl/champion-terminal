using Newtonsoft.Json;

namespace champion_terminal
{
    internal class ChampionService
    {
        private string ChampionUrl { get; set; }

        // TODO use latest version from version service
        private static string ChampionBaseUrl => "https://ddragon.leagueoflegends.com/cdn/12.17.1/data/en_US/champion/id.json";

        private static readonly HttpClient Client = new HttpClient();

        public ChampionService(string id)
        {
            ChampionUrl = ChampionBaseUrl.Replace("id", id);
        }

        public async Task<string> GetChampionData()
        {
            var response = await Client.GetAsync(ChampionUrl);
            var responseBody = await response.Content.ReadAsStringAsync();

            // var championData = JsonConvert.DeserializeObject<List<string>>(responseBody);

            return responseBody;
        }
    }
}
