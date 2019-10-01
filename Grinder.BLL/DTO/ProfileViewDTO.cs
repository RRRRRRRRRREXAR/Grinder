using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.DTO
{
    public class ProfileViewDTO
    {
        public int Id { get; set; }
        public UserDTO Viewer { get; set; }
        public DateTime Date { get; set; }
        public UserDTO Profile { get; set; }
    }
}
