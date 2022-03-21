using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_RestaurentApp.Models
{
    public partial class Item
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int BillId { get; set; }
        public int OrderNo { get; set; }

        public virtual Customer Bill { get; set; }
        public virtual Dish ItemNavigation { get; set; }
    }
}
