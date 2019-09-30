using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.DTO
{
    public class MessageDTO
    {
        public int Id {get;set;}
        public UserDTO Recivier { get; set; }
        public UserDTO Sender { get; set; }
        public DateTime Time { get; set; }
    }
}
