using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Models
{
    public class UserModel
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
        public ICollection<ImageModel> Images { get; set; }
        public ThumbnailModel ProfileImage { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
