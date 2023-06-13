using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.HelperFunctions
{
    public class PublisherTagHelperFunctions
    {
        public PublisherTag Create(string text)
        {

            PublisherTag NewTag = new PublisherTag();
            NewTag.Text = text;
            return NewTag;
        }
    }
}
