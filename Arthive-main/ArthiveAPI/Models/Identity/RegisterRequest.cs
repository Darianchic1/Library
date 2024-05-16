using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{
    [Required] 
    [Display(Name = "Name")] 
    public string Name { get; set; } = null!;
    [Required] 
    [Display(Name = "Email")] 
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;
}