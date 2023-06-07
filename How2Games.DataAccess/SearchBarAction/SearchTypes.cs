using How2Games.DataAccess.Data;
using How2Games.DataAccess.TagAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace How2Games.DataAccess.SearchBarAction
{
    public class SearchTypes : ISearchTypes
    {

        private readonly GamesContext _gamescontext;
        private readonly SteamApiContext _steamApiContext;

        // Constructor
        public SearchTypes(GamesContext gamescontext, SteamApiContext steamApiContext)
        {
            _gamescontext = gamescontext;
            _steamApiContext = steamApiContext;
        }

        public int LevenshteinDistance(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                dp[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                dp[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(
                        Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost
                    );
                }
            }

            return dp[s1.Length, s2.Length];
        }

        public async Task<HashSet<string>> GameSearchBar(string searchQuery)
        {
            var games1 = await _gamescontext.Games.Select(game => game.Name).ToListAsync();
            var games2 = await _steamApiContext.SteamGameIdName.Select(game => game.Name).ToListAsync();

            var combinedQuery = games1.Concat(games2).Distinct().ToList();

            for (int i = 0; i < combinedQuery.Count; i++)
            {
                combinedQuery[i] = combinedQuery[i].ToUpper();
            }
            searchQuery = searchQuery.ToUpper();

            var game = combinedQuery.Where(x => x.StartsWith(searchQuery));

            Dictionary<string, int> GmaeDistance = new Dictionary<string, int>();

            foreach (var i in game)
            {
                int Distance = LevenshteinDistance(searchQuery, i);
                GmaeDistance.TryAdd(i, Distance);
            }

            HashSet<string> searchResults = new HashSet<string>();

            foreach (var name in GmaeDistance.OrderBy(x => x.Value).Take(5))
            {
                searchResults.Add(name.Key);
            }

            return searchResults;
        }

    }
}
