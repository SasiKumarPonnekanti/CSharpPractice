using Microsoft.AspNetCore.Http;

namespace Cs_EmployeeManagementWebApp.Models
{
    public class ProfileData
    {
        public IFormFile ProfilePicture { get; set; }

        public string UploadStatus { get; set; }
        public string FileName { get; set; }
    }
}
