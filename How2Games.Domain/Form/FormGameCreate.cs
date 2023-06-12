using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.Form
{
    public class FormGameCreate
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string ImgUrl { get; set; }
        public string GenreTags { get; set; } 
        public string DeveloperTags { get; set; }
        public string PublisherTags { get; set; } 
    }
}
