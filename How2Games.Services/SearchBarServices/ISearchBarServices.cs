using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.SearchBarServices
{
    public interface ISearchBarServices
    {
        int LevenshteinDistance(string s1, string s2);
        Task<HashSet<string>> GameSearchBar(string searchQuery);
        Task<HashSet<Question>> QuestionSearchBar(string searchQuery, string gameName);


    }
}
