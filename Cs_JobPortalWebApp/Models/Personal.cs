using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cs_JobPortalWebApp.CustomValidators;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace Cs_JobPortalWebApp.Models
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
        [Required(ErrorMessage = "Feild Is Required")]
        
        [Remote("ValidateName", "Registration", ErrorMessage = "Name should cantain firstname middlename last name eg Mahendar Singh Dhoni")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
       
        [Remote("ValidPhone", "Registration", ErrorMessage = "Enter Valid Number like +919999999999")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        [EmailAddress]
        public string Email { get; set; }

        public string AlternateContact { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string ProfilePath { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public int? WorkExperience { get; set; }

        public virtual ICollection<CampanyInfo> CampanyInfos { get; set; }
        public virtual ICollection<EduInfo> EduInfos { get; set; }
        public virtual ICollection<ProjectInfo> ProjectInfos { get; set; }
    }
}
