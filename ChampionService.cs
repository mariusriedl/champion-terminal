using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace champion_terminal
{
    internal class ChampionService
    {
        private string ChampionId { get; set; }

        private string ChampionUrl { get; set; }

        private static string ChampionBaseUrl => "https://ddragon.leagueoflegends.com/cdn/version/data/en_US/champion/id.json";

        private static readonly HttpClient Client = new HttpClient();
        
        public ChampionService(string championId, string version)
        {
            ChampionId = championId;
            ChampionUrl = ChampionBaseUrl.Replace("id", championId).Replace("version", version);
        }

        public async void PrintChampionData()
        {
            var championData = await GetChampionData();
            var spells = GetSpells(championData);

            PrintSpells(spells);
        }

        private async Task<JObject> GetChampionData()
        {
            var response = await Client.GetAsync(ChampionUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            var championData = JObject.Parse(responseBody);

            return championData;
        }

        private JToken GetSpells(JObject championData)
        {
            var spells = championData?.SelectToken("data")?.SelectToken(ChampionId)?.SelectToken("spells");
            
            if(spells == null)
            {
                return JToken.Parse(string.Empty);
            }

            return spells;
        }

        private void PrintSpells(JToken spells)
        {
            foreach (var spell in spells)
            {
                var cooldowns = spell.SelectToken("cooldown")?.ToList();

                if (cooldowns == null)
                {
                    continue;
                }

                var level = 1;

                foreach (var item in cooldowns)
                {
                    Console.Write($"{level}: {item} ");
                    level++;
                }

                Console.WriteLine();
            }
        }
    }
}
