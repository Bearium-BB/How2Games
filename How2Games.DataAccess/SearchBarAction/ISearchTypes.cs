using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.SearchBarAction
{
    public interface ISearchTypes
    {
        int LevenshteinDistance(string s1, string s2);
        Task<HashSet<string>> GameSearchBar(string searchQuery);
    }
}
