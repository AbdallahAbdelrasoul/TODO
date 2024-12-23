
using Microsoft.EntityFrameworkCore;
using TODO.DataAccess;

namespace TODO.Presentation.ServiceCollectionExtensions
{
    public static class DataAccessServiceCollectionExtentions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<TodoDbContext>(opt =>
                opt.UseInMemoryDatabase("TODO_DB")
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors(true)
            );

            return services;
        }
    }
}
