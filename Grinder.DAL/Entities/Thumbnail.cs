using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.Entities
{
    public class Thumbnail:BaseEntity
    {
        public string Link { get; set; }
        public User UserId { get; set; }
    }
}
