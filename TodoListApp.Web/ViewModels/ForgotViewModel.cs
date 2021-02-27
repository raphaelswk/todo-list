using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Web.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
