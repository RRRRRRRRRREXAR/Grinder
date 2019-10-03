using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.Entities
{
    public class Notification:BaseEntity
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public User Recivier { get; set; }
    }
}
