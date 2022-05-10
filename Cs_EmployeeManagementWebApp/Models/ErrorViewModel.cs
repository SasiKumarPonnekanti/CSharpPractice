using System;

namespace Cs_EmployeeManagementWebApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ControllerName { get; set; }
        public string Actionname { get; set; }  
        public string ErrorMessage { get; set; }    
    }
}
