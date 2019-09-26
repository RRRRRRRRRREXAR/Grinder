using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.Entities
{
    public class Message:BaseEntity
    {
        public User To { get; set; }
        public User From { get; set; }
        public DateTime Time { get; set; }
    }
}
