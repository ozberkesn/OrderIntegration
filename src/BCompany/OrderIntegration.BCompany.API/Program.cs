using Microsoft.EntityFrameworkCore;
using OrderIntegration.BCompany.Bussiness.Abstract;
using OrderIntegration.BCompany.Bussiness.Concrete;
using OrderIntegration.BCompany.DataAccess.Context;
using OrderIntegration.BCompany.DataAccess.Repositories.OrderRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BCompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
