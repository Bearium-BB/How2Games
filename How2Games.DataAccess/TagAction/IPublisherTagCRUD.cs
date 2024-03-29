﻿using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.TagAction
{
    public interface IPublisherTagCRUD
    {
        void Insert(string text);
        void Update(int id, string text);
        PublisherTag Read(int id);
        void Delete(int id);
        PublisherTag Create(string text);
    }
}
