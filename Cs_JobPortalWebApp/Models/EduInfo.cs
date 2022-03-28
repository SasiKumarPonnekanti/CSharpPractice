using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_JobPortalWebApp.Models
{
    public partial class EduInfo
    {
        public int EduId { get; set; }
        public string EducationType { get; set; }
        public string InstituteName { get; set; }
        public string Specification { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Percentage { get; set; }
        public int? PersonId { get; set; }
        public DateTime Startdate { get; set; }

        public virtual Personal Person { get; set; }
    }
}
