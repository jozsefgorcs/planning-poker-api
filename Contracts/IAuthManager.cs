using Microsoft.AspNetCore.Identity;
using PlanningPoker.Api.Models.Users;

namespace PlanningPoker.Api.Contracts;

public interface IAuthManager
{
    Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
}