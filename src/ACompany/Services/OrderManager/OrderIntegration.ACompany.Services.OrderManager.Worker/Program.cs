using Microsoft.EntityFrameworkCore;
using OrderIntegration.ACompany.Services.OrderManager.Application.Handlers;
using OrderIntegration.ACompany.Services.OrderManager.Infrastructure;
using OrderIntegration.ACompany.Services.OrderManager.Worker.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContextPool<OrderDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
    {
        configure.MigrationsAssembly("OrderIntegration.ACompany.Services.OrderManager.Infrastructure");
    });
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddOrdersListCommandHandler).Assembly));
builder.Services.AddHostedService<DailyOrderWorker>();
builder.Services.AddHostedService<HourlyOrderWorker>();

var host = builder.Build();
host.Run();
