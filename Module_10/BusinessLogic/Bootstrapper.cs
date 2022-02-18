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
                .AddScoped<IUniverService<StudentDb>, UniverService<StudentDb>>()
                .AddScoped<IUniverService<LectorDb>, UniverService<LectorDb>>()
                .AddScoped<IUniverService<LectureDb>, UniverService<LectureDb>>()
                .AddScoped<IUniverService<HomeWorkDb>, UniverService<HomeWorkDb>>()
                .AddScoped<IUniverService<AttendanceLog>, UniverService<AttendanceLog>>()
                .AddScoped<IUniverLinkService, UniverLinkService>();
        }
    }
}