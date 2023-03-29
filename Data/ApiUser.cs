using Microsoft.AspNetCore.Identity;

namespace PlanningPoker.Api.Data;

public class ApiUser : IdentityUser
{
    public string NickName { get; set; }
}