using champion_terminal;

while(true)
{
    var championId = Console.ReadLine();

    if(championId == string.Empty || championId == null)
    {
        continue;
    }

    var versionService = new VersionService();
    var version = await versionService.GetLatestVersion();
    var championService = new ChampionService(championId, version);
    championService.PrintChampionData();
}
