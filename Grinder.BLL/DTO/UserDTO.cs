using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string MeetGoal { get; set; }
        public string Other { get; set; }
        public string Interests { get; set; }
        public bool IsAnonymous { get; set; }
        public ICollection<ImageDTO> Images { get; set; }
        public ImageDTO ProfileImage { get; set; }
        public string Password { get; set; }
    }
}
