using ExerciseProject.Data;
using ExerciseProject.Models.ModelMapper;
using ExerciseProject.Repository.Implementation;
using ExerciseProject.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbConnectionString")));
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConnectionString")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audiance"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
builder.Services.AddScoped<IEmployeeRespository, EmployeeRespository>();
builder.Services.AddAutoMapper(typeof(ModelMapper));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("EmployeeDB")
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequiredUniqueChars = 1;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
    option.Lockout.MaxFailedAccessAttempts= 5;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
