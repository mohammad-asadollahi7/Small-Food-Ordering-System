using Data;
using Model;
using Repository;
using Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();    
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<DataAccess<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
