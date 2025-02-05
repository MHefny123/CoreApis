﻿using System;
using System.Collections.Generic;

namespace CoreApi.Models
{
    public partial class EmployeeDetails
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Emailid { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
    }
}
