using System;
using System.Collections.Generic;

#nullable disable

namespace FirstNaukri.Models
{
    public partial class Application
    {
        public int AppId { get; set; }
        public int? ProfileId { get; set; }
        public int? JobSeekerId { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
    }
}
