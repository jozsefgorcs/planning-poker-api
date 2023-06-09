﻿using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Api.Models.Users;

public class LoginDto
{
    [Required] 
    [EmailAddress] 
    public string Email { get; set; }
    
    [Required] 
    public string Password { get; set; }
}