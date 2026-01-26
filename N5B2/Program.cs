using AppAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// bật cors
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowMVC", p =>
    p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});


builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapControllers();
app.UseHttpsRedirection();


app.Run();



