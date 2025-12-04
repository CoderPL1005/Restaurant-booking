using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BACKEND.IRepo;
using BACKEND.API.Middleware;
using BACKEND.Model.Common;
using BACKEND.Model.Context;
using BACKEND.Repo;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config connect database
builder.Services.AddDbContext<RTCContext>(o => o.UseSqlServer
    (Config.ConnectionString));
builder.Services.AddMvc().AddJsonOptions(otp => otp.JsonSerializerOptions.PropertyNamingPolicy = null);


//config CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserPermissionService, UserPermissionService>();

//Load JWT settings
var jwtSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSection);
var jwtSettings = jwtSection.Get<JwtSettings>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        NameClaimType = "sub" // Để middleware lấy đúng UserID
    };
});
builder.Services.AddAuthorization();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true; //Chuyển tất cả URL thành chữ thường
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<DynamicAuthorizationMiddleware>();

app.MapControllers();

app.UseCors("MyCors");

app.Run();
