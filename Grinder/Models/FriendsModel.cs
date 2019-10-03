using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Models
{
    public class FriendsModel
    {
        public int Id { get; set; }
        public UserModel User1 { get; set; }
        public UserModel User2 { get; set; }
        public string Status { get; set; }
    }
}
