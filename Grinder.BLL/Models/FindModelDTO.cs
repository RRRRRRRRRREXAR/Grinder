using Grinder.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.Models
{
    public class FindModelDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MeetGoal { get; set; }
        public ThumbnailDTO ProfileImage { get; set; }
    }
}
