namespace BusinessLogic
{
    using Domain;
    using Domain.Models;
    using Microsoft.Extensions.DependencyInjection;

    public static class Bootstrapper
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            return services
                .AddScoped<IStudentsService<Student>, StudentsService<Student>>()
                .AddScoped<IStudentsService<Lector>, StudentsService<Lector>>();
        }
    }
}