using DatingApp.BAL.Contacts;
using DatingApp.BAL.Services;
using DatingApp.DAL.Contacts;
using DatingApp.DAL.Data;
using DatingApp.DAL.Models;
using DatingApp.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
// Dependence Injection
// Tự động khởi tạo class sau đó tiêm vào nó tự động khởi tạo
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHobbyRepository, HobbyRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

// Map section
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("EF_postgreSql"))
    );

// Hứng 
//AppDbContext.;

/// <summary>
/// Mã hoá và sinh ra jwt
/// jwt gửi lên 
/// </summary>
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

// Xử lý, tính toán và configuration
builder.Services.AddAuthentication
    (JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            // Tự cấp token
            ValidateIssuer = false, //Tự cấp, nếu cấp phải chỉ dịch vụ mih chọn
            ValidateAudience = false,

            // Ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes), // Sử dụng thuật toán đối xứng

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Web API cho dự án thực tập bên công ty NashTech", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Đặt trc authorization

app.UseAuthorization();

app.MapControllers();

app.Run();
