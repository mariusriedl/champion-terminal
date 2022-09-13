namespace champion_terminal
{
    internal class ValidationService
    {
        public ValidationService() { }

        public async Task<bool> Validate(string input)
        {
            var champions = await RiotApiService.GetAllChampions();
            var match = champions.FirstOrDefault(str => str.Contains(input));

            if (match == null)
            {
                return false;
            }

            return true;
        }
    }
}
