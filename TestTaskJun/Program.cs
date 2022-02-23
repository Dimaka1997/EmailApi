using TestTaskJun.Interfaces;
using TestTaskJun.Services;
using TestTaskJun.Settings;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var commonSettings = builder.Configuration.GetSection(nameof(CommonSettings)).Get<CommonSettings>();
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IDbManager>(new DbManager(commonSettings.ConnectionString));


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

app.Run();
