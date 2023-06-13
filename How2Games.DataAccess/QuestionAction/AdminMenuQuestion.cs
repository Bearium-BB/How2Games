using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.DataAccess.Data;
using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using Newtonsoft.Json;

namespace How2Games.DataAccess.QuestionAction
{
    public class AdminMenuQuestion : IAdminMenuQuestion
    {
        
    private readonly GamesContext _gamesContext;
        public AdminMenuQuestion(GamesContext context)
        {
            _gamesContext = context;
        }
        public void DeleteQuuestion(int questionId)
        {
            var question = _gamesContext.Questions.FirstOrDefault(x=> x.Id == questionId);
            if (question != null)
            {

                _gamesContext.Questions.Remove(question);

            }
            
        }
    }
}
