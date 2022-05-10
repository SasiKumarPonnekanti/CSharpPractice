using System;
using System.Collections.Generic;

#nullable disable

namespace FirstNaukri.Models
{
    public partial class Employer
    {
        public Employer()
        {
            JobProfiles = new HashSet<JobProfile>();
        }

        public int EmployerId { get; set; }
        public string EmployerName { get; set; }
        public string Designation { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public string OrgName { get; set; }
        public string OrgType { get; set; }
        public string Sector { get; set; }
        public string OrgAddress { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string OrgContact { get; set; }
        public string OrgEmail { get; set; }
        public string WebAddress { get; set; }

        public virtual ICollection<JobProfile> JobProfiles { get; set; }
    }
}
