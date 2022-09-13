using champion_terminal;
while(true)
{
    var input = Console.ReadLine();

    if (input == string.Empty || input == null)
    {
        continue;
    }

    if(input == "help" || input == "h")
    {
        Console.WriteLine("'champions or c' prints out all valid champion inputs");
        Console.WriteLine("'<champion>' prints information about specified champion");
        Console.WriteLine("'clear' clears console");
        continue;
    }

    if(input == "champions" || input == "c")
    {
        var champions = await RiotApiService.GetAllChampions();
        Console.WriteLine(string.Join(", ", champions));
        continue;
    }

    if(input == "clear")
    {
        Console.Clear();
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
