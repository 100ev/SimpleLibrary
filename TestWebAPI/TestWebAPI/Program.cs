using System.Text;
using BookStore.BL.Extention;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using TestWebAPI.CommandHandlers;
using TestWebAPI.DL.Extention;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Repositories.MsSql;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.DL.Services;
using TestWebAPI.HealthChecks;
using TestWebAPI.Middleware;

var logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSerilog(logger);
// Add services to the container.
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.RegistratesRepositories().RegisterServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck<SqlHealthCheck>("Sql Server")
    .AddCheck<CustomHealthCheck>("Custom Health Check")
    .AddUrlGroup(new Uri("https://google.bg"), name: "Google Service");

builder.Services.AddMediatR(typeof(GetAllBooksCommandHandler).Assembly);



builder.Services.AddSwaggerGen(x =>
{
    var jwt = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    x.AddSecurityDefinition(jwt.Reference.Id, jwt);
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwt, Array.Empty<string>() }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;

        options.SaveToken = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateActor = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();
//app.MapHealthChecks("/health");

app.RegisterHealthChecks();
app.Run();
