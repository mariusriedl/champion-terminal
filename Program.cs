using champion_terminal;

while(true)
{
    var input = Console.ReadLine();

    if (input == string.Empty || input == null)
    {
        continue;
    }

    var validationService = new ValidationService();
    var validation = await validationService.Validate(input);

    if(!validation)
    {
        Console.WriteLine($"{input} is not a valid input");
        continue;
    }

    var versionService = new VersionService();
    var version = await versionService.GetLatestVersion();

    var championService = new ChampionService(input, version);
    championService.PrintChampionData();
}
