using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.DTO
{
    public class FriendsDTO
    {
        public int Id { get; set; }
        public UserDTO User1 { get; set; }
        public UserDTO User2 { get; set; }
        public string Status { get; set; }
    }
}
