using Microsoft.EntityFrameworkCore;
using OficinaJD.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"
 )));

 builder.Services.AddCors(options =>
 {
     options.AddPolicy("FrontEnd", policy =>
     {
         policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
     });
 });

 var app = builder.Build();

 app.UseCors("FrontEnd");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

