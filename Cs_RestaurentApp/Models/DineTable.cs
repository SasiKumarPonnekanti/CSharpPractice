using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_RestaurentApp.Models
{
    public partial class DineTable
    {
        public int TableNo { get; set; }
        public int? IsBooked { get; set; }
        public int? TableBillId { get; set; }
    }
}
