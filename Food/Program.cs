using Data;
using Microsoft.Net.Http.Headers;
using Model;
using Repository.Repository;
using Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("mypolicy",
        policy =>
        {
            policy.WithOrigins("*").WithHeaders(HeaderNames.ContentType, "x-custom-header");
        });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(200);
    opt.Cookie.HttpOnly = true;
});
builder.Services.AddScoped<IUserService, UserService>();    
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<Order>();

builder.Services.AddScoped(typeof(DataAccess<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseSession();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
