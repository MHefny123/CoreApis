﻿using System;
using System.Collections.Generic;

namespace CoreApi.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
