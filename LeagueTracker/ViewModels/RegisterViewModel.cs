using System.ComponentModel.DataAnnotations;

namespace LeagueTracker.ViewModels;

public class RegisterViewModel
{
    [EmailAddress]
    [Display(Name = "Email address")]
    [Required(ErrorMessage = "Email address is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [Display(Name = "Username")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Please, confirm your password")]
    [Display(Name = "Confirm password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string PasswordConfirm { get; set; }
}