﻿namespace DataAccess
{
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class Bootstrapper
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UniverDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            DefaultDB.CreateDafaultDB(new UniverDbContext(optionsBuilder.Options));

            return services
                .AddAutoMapper(typeof(MapperProfile))
                .AddDbContext<UniverDbContext>(options => options.UseNpgsql(connectionString))
                .AddScoped<IUniverRepository<StudentDb>, UniverRepository<StudentDb>>()
                .AddScoped<IUniverRepository<LectorDb>, UniverRepository<LectorDb>>();
        }
    }
}