using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grinder.DAL.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string MeetGoal { get; set; }
        public string Other { get; set; }
        public string Interests { get; set; }
        public bool IsAnonymous { get; set; }
        public ICollection<Image> Images { get; set; }
        public Thumbnail ProfileImage { get; set; }
        public bool IsOnline { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int ProfilePictureId { get; set; }
    }
}
