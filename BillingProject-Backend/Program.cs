using BillingProject_Backend.Infrastructure.Database;
using BillingProject_Backend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnectionFactory, SqlDbConnectionFactory>();
builder.Services.AddScoped<ILookupRepository, LookupRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

//Builder para recibir Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.AllowAnyHeader()
                  .AllowAnyMethod()
                  .WithOrigins("http://localhost:*");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowAngular");

app.MapControllers();

app.Run();
