using Microsoft.EntityFrameworkCore;
using FruitWebApiREST.Data;

var builder = WebApplication.CreateBuilder(args);

// Dados da memória
builder.Services.AddDbContext<FruitContext>
    (opt => opt.UseInMemoryDatabase("FruitsDB"));

// Dados da base de dados
/*builder.Services.AddDbContext<FruitContext>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));*/

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
