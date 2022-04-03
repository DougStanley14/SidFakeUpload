using Microsoft.AspNetCore.Server.Kestrel.Core;
using microsvc_file_management.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<NDDSFilesService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(3);
});


var corsUse = "corsAnyAnyAny";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "corsAnyAnyAny",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });

    options.AddPolicy(name: "corsLocal",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200/", "https://localhost:7072").AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsUse);

app.UseAuthorization();

app.MapControllers();

app.Run();
