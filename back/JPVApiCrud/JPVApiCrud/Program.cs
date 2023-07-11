using FluentAssertions.Common;
using JPVApiCrud.Repository;
using JPVApiCrud.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddScoped<ICandidadoRepository, CandidatoRepository>();
builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("teste",
                      policy =>
                      {
                          policy
                          .WithOrigins("*")
                          .AllowAnyMethod()
                          .SetIsOriginAllowed(_=>true)
                          .AllowAnyHeader()
                          .Build();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JpvContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db_jpv")));


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

//cors
app.UseCors("teste");







