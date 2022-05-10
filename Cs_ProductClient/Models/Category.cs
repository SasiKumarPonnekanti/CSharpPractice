using System.ComponentModel.DataAnnotations;

namespace Cs_ProductClient.Models
{
    public class Category
    {
       
        public int CategoryRowId { get; set; }
        [Required]
        [StringLength(50)]
        public string? CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set; }
        [Required]
        public int BasePrice { get; set; }
        
    }
}
