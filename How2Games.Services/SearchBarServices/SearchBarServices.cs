using How2Games.DataAccess.GameAction;
using How2Games.DataAccess.SearchBarAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.SearchBarServices
{
    public class SearchBarServices : ISearchBarServices
    {
        private readonly ISearchTypes _searchTypes;

        public SearchBarServices(ISearchTypes searchTypes)
        {
            _searchTypes = searchTypes;
        }

        public int LevenshteinDistance(string s1, string s2)
        {
            return _searchTypes.LevenshteinDistance(s1, s2);
        }
        public async Task<HashSet<string>> GameSearchBar(string searchQuery) { 
            return await _searchTypes.GameSearchBar(searchQuery);
        }

    }
}
