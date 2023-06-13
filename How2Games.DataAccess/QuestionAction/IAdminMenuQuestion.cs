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
    public interface IAdminMenuQuestion
    {
        void DeleteQuuestion(int questionId)
    }
}
