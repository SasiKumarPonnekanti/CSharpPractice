using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Cs_JobPortalWebApp.Models
{
    public partial class CampanyInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Feild Is Required")]
        public string CampanyName { get; set; }
        [Required(ErrorMessage = "Feild Is Required")]
        public string Discription { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public string Location { get; set; }
        public int? PersonId { get; set; }

        public virtual Personal Person { get; set; }
    }
}
