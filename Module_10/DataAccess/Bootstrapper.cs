namespace DataAccess
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class Bootstrapper
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            DefaultDB.CreateDafaultDB(new StudentDbContext(optionsBuilder.Options));

            return services
                .AddAutoMapper(typeof(MapperProfile))
                .AddDbContext<StudentDbContext>(options => options.UseNpgsql(connectionString))
                .AddScoped<IStudentsRepository, StudentsRepository>();
        }
    }
}