using Microsoft.AspNetCore.Http;

namespace Cs_JobPortalWebApp.Models
{
    public class ProfileData
    {
        public IFormFile Image { get; set; }

        public string ImageUploadStatus { get; set; }
        public string ImageFileName { get; set; }
        public IFormFile Resume { get; set; }

        public string ResumeUploadStatus { get; set; }
        public string ResumeFileName { get; set; }

    }
}
