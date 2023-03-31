using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Configurations;
using PlanningPoker.Api.Contracts;
using PlanningPoker.Api.Data;
using PlanningPoker.Api.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PlanningPokerDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services
    .AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PlanningPokerDbContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll",
        b => b
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});

builder.Host
    .UseSerilog((ctx, lc) => lc.WriteTo.Console()
        .ReadFrom
        .Configuration(ctx.Configuration));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStoriesRepository, StoriesRepository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();