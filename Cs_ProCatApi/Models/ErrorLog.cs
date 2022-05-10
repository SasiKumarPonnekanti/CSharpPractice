namespace Cs_ProCatApi.Models
{
    public class ErrorLog
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        [StringLength(100)]
        public string ControllerName { get; set; }
        [Required]
        [StringLength(100)]
        public string RequestMethodType { get; set; }
        
        public DateTime Date { get; set; }
        public string Time { get; set; }
        [Required]
        [StringLength(200)]
        public string ErrorMessage { get; set; }
        [Required]
       

        public string StackTrace { get; set; }

    }
}
