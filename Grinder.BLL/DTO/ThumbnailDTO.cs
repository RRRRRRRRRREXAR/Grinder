﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.DTO
{
    public class ThumbnailDTO
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public UserDTO UserId { get; set; }
    }
}
