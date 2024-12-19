using dependencyinjection.Repositories;
using dependencyinjection.Repositories.Contracts;
using dependencyinjection.Services;
using dependencyinjection.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace dependencyinjection;

public static class DependencyExtensions
{
    public static void AddSqlConnection(this IServiceCollection services, string connectionString)
    {
        services.AddScoped(x => new SqlConnection(connectionString));
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
    }
}