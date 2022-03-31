global using System.ComponentModel.DataAnnotations;
namespace Cs_CoreWebApi.Models
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
        public int CatogeryRowId { get; set; } 
        public Category? category { get; set; }  
        public int Price { get; set; }
    }

    public class LogInfo
    {

         public int RequestID { get; set; }
        public string? ControllerName { get; set; }


        public DateOnly Date { get; set; }
        public TimeOnly? Time { get; set;}
    }
    public class ErrorLogs
    {

    }
}
