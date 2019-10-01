using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public UserModel UserId { get; set; }
    }
}
