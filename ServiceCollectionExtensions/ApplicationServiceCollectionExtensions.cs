using TODO.Application.TodoItems;

namespace TODO.Presentation.ServiceCollectionExtensions
{
    public static class ApplicationServiceCollectionExtensions
    {

        public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoItemsService, TodoItemsService>();
            services.AddScoped<ITodoItemsQueryService, TodoItemsQueryService>();

            return services;
        }
    }
}
