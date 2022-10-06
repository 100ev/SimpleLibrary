using BookStore.BL.Extention;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using MediatR;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using TestWebAPI.CommandHandlers;
using TestWebAPI.DL.Extention;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Repositories.MsSql;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.DL.Services;
using TestWebAPI.HealthChecks;

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
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IBookService, BookService>();
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.MapHealthChecks("/health");

app.RegisterHealthChecks();
app.Run();
