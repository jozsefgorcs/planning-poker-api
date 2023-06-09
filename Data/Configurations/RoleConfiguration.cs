﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlanningPoker.Api.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public const string Admin = "Admin";
    public const string User = "User";

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole
            {
                Name = Admin,
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = User,
                NormalizedName = "USER"
            });
    }
}