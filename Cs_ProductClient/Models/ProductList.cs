using System.Collections.Generic;

namespace Cs_ProductClient.Models
{
    public class ProductList
    {
        public string CategoryName { get; set; }    
        public IEnumerable<Product> products { get; set; }
    }
}
