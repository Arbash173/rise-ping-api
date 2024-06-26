//using Microsoft.EntityFrameworkCore;
//using RisePingAPIs.Services;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
//builder.Services.AddTransient<IEmailService, EmailService>();
//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
//                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                             .AddEnvironmentVariables();

//// Configure DbContext with SQL Server
//builder.Services.AddDbContext<RisePingContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using Microsoft.EntityFrameworkCore;
using RisePingAPIs.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services and dependencies
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<RisePingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

