using System;
using System.Collections.Generic;

#nullable disable

namespace FirstNaukri.Models
{
    public partial class Personal
    {
        public Personal()
        {
            CampanyInfos = new HashSet<CampanyInfo>();
            EduInfos = new HashSet<EduInfo>();
            ProjectInfos = new HashSet<ProjectInfo>();
        }

        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string AlternateContact { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string ProfilePath { get; set; }
        public int? WorkExperience { get; set; }

        public virtual ICollection<CampanyInfo> CampanyInfos { get; set; }
        public virtual ICollection<EduInfo> EduInfos { get; set; }
        public virtual ICollection<ProjectInfo> ProjectInfos { get; set; }
    }
}
