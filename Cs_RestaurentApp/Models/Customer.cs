using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_RestaurentApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Items = new HashSet<Item>();
        }

        public int BillId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? VisitedAt { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
