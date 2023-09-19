using Infra.Data.Todo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.Todo;

public class DependencyInjection
{
    public static IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
    {
        //Adding Database Connection
        services.AddDbContext<TodoContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            
        //Adding AutoMapper
        /*
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        */
            
        //Adding Mediator
        /*services.AddMediatR(new[]
        {
            typeof(ProductCommandHandler),
            typeof(CategoryCommandHandler),
            typeof(OrderCommandHandler)
        });*/

        //Adding Services
        /*services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<ICategoryAppService, CategoryAppService>();
        services.AddScoped<IOrderAppService, OrderAppService>();
        services.AddScoped<IOrderRepository, OrderRepository>();*/

        return services;
    }
}