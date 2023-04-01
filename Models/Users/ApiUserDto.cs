using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Api.Models.Users;

public class ApiUserDto : LoginDto
{
    [Required] public string NickName { get; set; }
}