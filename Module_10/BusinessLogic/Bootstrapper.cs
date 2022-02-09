namespace BusinessLogic
{
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.Extensions.DependencyInjection;

    public static class Bootstrapper
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            return services
                .AddScoped<IUniverService<StudentDb>, StudentsService<StudentDb>>()
                .AddScoped<IUniverService<LectorDb>, StudentsService<LectorDb>>();
        }
    }
}