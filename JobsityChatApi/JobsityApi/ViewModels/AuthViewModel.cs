using System.ComponentModel.DataAnnotations;

namespace JobsityApi.ViewModels;

public class AuthViewModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
