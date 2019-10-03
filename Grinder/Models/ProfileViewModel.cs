using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public UserModel Viewer { get; set; }
        public DateTime Date { get; set; }
        public UserModel Profile { get; set; }
    }
}
