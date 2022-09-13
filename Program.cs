using champion_terminal;

while(true)
{
    var championId = Console.ReadLine();

    if(championId == string.Empty || championId == null)
    {
        continue;
    }

    var versionService = new VersionService();
    var championService = new ChampionService(championId);

    var version = await versionService.GetLatestVersion();
    championService.PrintChampionData();

    Console.WriteLine(version);
}
