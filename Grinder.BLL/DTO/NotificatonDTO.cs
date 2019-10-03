using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.DTO
{
    public class NotificatonDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public UserDTO Recivier { get; set; }
    }
}
