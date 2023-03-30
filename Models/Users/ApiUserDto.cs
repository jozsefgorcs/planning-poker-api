using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Api.Models.Users;

public class ApiUserDto
{
    [Required]
    public string NickName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}