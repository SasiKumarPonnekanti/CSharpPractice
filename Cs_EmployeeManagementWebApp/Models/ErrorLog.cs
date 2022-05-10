using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_EmployeeManagementWebApp.Models
{
    public partial class ErrorLog
    {
        public int RequestId { get; set; }
        public DateTime? RequestDateTime { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public long ExecutionCompletionTime { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
