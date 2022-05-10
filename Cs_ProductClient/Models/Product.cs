using System.ComponentModel.DataAnnotations;

namespace Cs_ProductClient.Models
{
    public class Product
    {
        
        public int ProductRowId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductId { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int CategoryRowId { get; set; }
        [Required]
        public int Price { get; set; }

       
       
    }
}
