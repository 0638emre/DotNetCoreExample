using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//bu þekilde verilmesi best practice deðil. servisler kendi katmanlarnýda register edilmeli.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMeetService, MeetService>();
builder.Services.AddDbContext<DotNetCoreExampleDB>(option =>
    option.UseSqlServer("Data Source = localhost;Initial Catalog=DotNetCoreExampleDB;Integrated Security=true;TrustServerCertificate=True"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
