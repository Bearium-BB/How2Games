using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.HelperFunctions
{
    internal class DeveloperTagHelperFunctions
    {
        public DeveloperTag Create(string text)
        {

            DeveloperTag NewTag = new DeveloperTag();
            NewTag.Text = text;
            return NewTag;
        }
    }
}
