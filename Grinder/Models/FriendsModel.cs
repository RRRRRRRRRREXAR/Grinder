﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Models
{
    public class FriendsModel
    {
        public int Id { get; set; }
        public ProfileModel Sender { get; set; }
        public ProfileModel Recivier { get; set; }
        public string Status { get; set; }
    }
}
