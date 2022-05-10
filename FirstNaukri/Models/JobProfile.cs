using System;
using System.Collections.Generic;

#nullable disable

namespace FirstNaukri.Models
{
    public partial class JobProfile
    {
        public int ProfileId { get; set; }
        public int? EmployerId { get; set; }
        public string CampanyName { get; set; }
        public string Designation { get; set; }
        public string JobName { get; set; }
        public string MinExperience { get; set; }
        public int? Lpa { get; set; }
        public string EmploymentType { get; set; }
        public string Locations { get; set; }
        public string JobDiscription { get; set; }
        public string SkillSet { get; set; }
        public string OtherInfo { get; set; }
        public string Status { get; set; }

        public virtual Employer Employer { get; set; }
    }
}
