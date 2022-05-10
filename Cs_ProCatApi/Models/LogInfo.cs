namespace Cs_ProCatApi.Models
{
    public class LogInfo
    {
        [Key]
        public int RequestID { get; set; }
        [Required]
        [StringLength(100)]
        public string? ControllerName { get; set; }
        [Required]
        [StringLength(100)]
        public string RequestMethodType { get; set; }    
        public DateTime Date { get; set; }
        public string Time { get; set; }
    }
}
