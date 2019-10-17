using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Models
{
    public class InviteModel
    {
        public ProfileModel Reciveier { get; set; }
        public string Status { get; set; }
    }
}
