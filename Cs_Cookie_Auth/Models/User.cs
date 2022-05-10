using System.ComponentModel.DataAnnotations;

namespace Cs_Cookie_Auth.Models
{
    public class User
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
