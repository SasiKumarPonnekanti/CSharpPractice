namespace Cs_ProCatApi.Models
{
    public class Product
    {

        [Key]
        public int ProductRowId { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        [Required]
        public int CategoryRowId { get; set; }
        public Category? category { get; set; }
        [NonNegative]
        public int Price { get; set; }
    }
}
