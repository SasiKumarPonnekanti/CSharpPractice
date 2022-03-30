using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Cs_JobPortalWebApp.Models
{
    public partial class EduInfo
    {
        public int EduId { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public string EducationType { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public string InstituteName { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public string Specification { get; set; }
        public DateTime CompletionDate { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public int Percentage { get; set; }
        public int? PersonId { get; set; }
        public DateTime Startdate { get; set; }

        public virtual Personal Person { get; set; }
    }
}
