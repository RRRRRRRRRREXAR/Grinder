using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.Entities
{
    public class Message:BaseEntity
    {
        public User Recivier { get; set; }
        public User Sender { get; set; }
        public DateTime Time { get; set; }
    }
}
