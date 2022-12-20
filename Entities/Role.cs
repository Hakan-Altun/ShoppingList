﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleType { get; set; }
        public ICollection<User> Users { get; set; }    
    }
}
