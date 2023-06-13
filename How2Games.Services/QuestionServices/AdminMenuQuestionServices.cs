using How2Games.DataAccess.QuestionAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.QuestionServices
{
    public class AdminMenuQuestionServices
    {
        private readonly IAdminMenuQuestion _adminMenuQuestion;

        public AdminMenuQuestionServices(IAdminMenuQuestion adminMenuQuestion)
        {
            _adminMenuQuestion = adminMenuQuestion;
        }

        public void DeleteQuuestion(int questionId)
        {
            _adminMenuQuestion.DeleteQuuestion(questionId);
        }


    }
}
