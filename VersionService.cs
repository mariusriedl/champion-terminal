using Newtonsoft.Json;

namespace champion_terminal
{
    internal class VersionService
    {
        private static string VersionUrl => "https://ddragon.leagueoflegends.com/api/versions.json";

        private static readonly HttpClient Client = new();

        public VersionService() { }

        public async Task<string> GetLatestVersion()
        {
            var versions = await GetVersions();
            var latestVersion = versions.First().ToString();

            return latestVersion;
        }

        private async Task<List<string>> GetVersions()
        {
            var response = await Client.GetAsync(VersionUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            var versions = JsonConvert.DeserializeObject<List<string>>(responseBody);

            return versions ?? new List<string>();
        }
    }
}
