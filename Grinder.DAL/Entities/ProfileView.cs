using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.Entities
{
    public class ProfileView:BaseEntity
    {
        public User Viewer { get; set; }
        public DateTime Date { get; set; }
        public User Profile { get; set; }
    }
}
