using System.Collections.Generic;

namespace Cs_JobPortalWebApp.Models
{
    public class FullInfo
    {
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string AlternateContact { get; set; }
        public string Adress { get; set; }

        public int? WorkExperience { get; set; }
        public string HighestEducation { get; set; }
        public IEnumerable<ProjectInfo> Projects {get; set;}
        public IEnumerable<EduInfo> Educations { get; set; }
        public IEnumerable<CampanyInfo> Campanys { get; set;}

        public string ImagePath { get; set;}
        public string Resumepath { get; set; }  
    }
}
