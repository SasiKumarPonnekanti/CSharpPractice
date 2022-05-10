namespace Cs_ProCatApi.Models
{
    public class Category
    {


        [Key]
        public int CategoryRowId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set; }
        [Required]
        [NonNegative]
       public int BasePrice { get; set; }
       
        public ICollection<Product>? Products { get; set; }
    }
}
