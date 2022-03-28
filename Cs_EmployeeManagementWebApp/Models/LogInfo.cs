using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_EmployeeManagementWebApp.Models
{
    public partial class LogInfo
    {
        public int RequestId { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Controllername { get; set; }
        public string ActionName { get; set; }
        public long? ElapsedTime { get; set; }
    }
}
