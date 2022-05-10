using System;
using System.Collections.Generic;

#nullable disable

namespace Cs_RestaurentApp.Models
{
    public partial class Dish
    {
        public Dish()
        {
            Items = new HashSet<Item>();
        }

        public int DishId { get; set; }
        public string DishName { get; set; }
        public int Price { get; set; }
        public int CatogiryId { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
