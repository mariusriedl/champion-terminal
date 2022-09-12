using champion_terminal;

var versionService = new VersionService();
var championService = new ChampionService("Riven");

var version = await versionService.GetLatestVersion();
var championData = await championService.GetChampionData();

Console.WriteLine(version);
Console.WriteLine(championData);

Console.ReadLine();
