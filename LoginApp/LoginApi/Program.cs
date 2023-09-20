using LoginApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.Parse("8.0.29")));

//builder.Services.AddDbContext<AppDbContext>(options => 
//{
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnetion"), ServerVersion.Parse("8.0.29") ??
//        throw new InvalidOperationException("Connection String 'Default Connection' not found"));        
//});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
