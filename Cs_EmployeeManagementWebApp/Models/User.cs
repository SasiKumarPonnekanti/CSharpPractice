using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_EmployeeManagementWebApp.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
    }
}
