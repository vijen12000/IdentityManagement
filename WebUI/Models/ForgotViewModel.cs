using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
