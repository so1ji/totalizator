using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Totalizator.Models.DbModel;

namespace Totalizator.Models.DomenModel
{
    public class UserDomenModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles{ get; set;}
    }
}