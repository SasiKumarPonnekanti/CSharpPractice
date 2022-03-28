using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_JobPortalWebApp.Models
{
    public partial class ProjectInfo
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Discription { get; set; }
        public DateTime CompletionDate { get; set; }
        public int? PersonId { get; set; }

        public virtual Personal Person { get; set; }
    }
}
