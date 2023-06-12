using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public How2GamesUser user { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
