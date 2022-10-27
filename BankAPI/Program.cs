using System.Text;
using System.Text.Json.Serialization;
using Application.DTOs;
using Application.Helpers;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

var customerConfig = new MapperConfiguration(config =>
{
    config.CreateMap<PostCustomerDTO, Customer>();
    config.CreateMap<PutCustomerDTO, Customer>();
    config.CreateMap<PostAccountDTO, Account>();
    config.CreateMap<PutAccountDTO, Account>();
}).CreateMapper();

builder.Services.AddSingleton(customerConfig);

builder.Services.AddDbContext<RepositoryDbContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddScoped<BankRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("AppSettings:Secret")))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", (policy) =>
    {
        policy.RequireRole("Admin");
    });
});

Application.DependencyResolver.DependencyResolverService.RegisterInfrastructureLayer(builder.Services);
Infrastructure.DependencyResolver.DependencyResolverService.RegisterInfrastructureLayer(builder.Services);
/*
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200", "https://localhost:7219").AllowAnyHeader()
                .AllowAnyMethod();
        });
});
*/

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    //options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    options.SetIsOriginAllowed(options => true)
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});
//app.UseCors(MyAllowSpecificOrigins);

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();