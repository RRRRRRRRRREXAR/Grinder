using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public UserModel Recivier { get; set; }
        public UserModel Sender { get; set; }
        public DateTime Time { get; set; }
    }
}
