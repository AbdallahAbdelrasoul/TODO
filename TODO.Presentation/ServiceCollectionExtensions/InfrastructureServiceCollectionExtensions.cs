using TODO.Domain.Shared.Repositories;
using TODO.Infrastructure.Repositories;

namespace TODO.Presentation.ServiceCollectionExtensions
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
