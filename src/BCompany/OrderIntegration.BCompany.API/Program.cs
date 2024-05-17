using Microsoft.EntityFrameworkCore;
using OrderIntegration.BCompany.Bussiness.Abstract;
using OrderIntegration.BCompany.Bussiness.Concrete;
using OrderIntegration.BCompany.DataAccess;
using OrderIntegration.BCompany.DataAccess.Context;
using OrderIntegration.BCompany.DataAccess.Repositories.OrderRepositories;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BCompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderSoapService, OrderSoapService>();
builder.Services.AddSoapCore();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.EnsureSeedData(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IOrderSoapService>("/Orders.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});


app.Run();
