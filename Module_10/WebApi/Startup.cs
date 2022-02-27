namespace WebApi
{
    using BusinessLogic;
    using DataAccess;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using WebApi.Configurations;
    using WebApi.UIModels;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfileUI));
            services.AddControllers();
            services.AddFluentValidation();
            services.AddTransient<IValidator<StudentUIPost>, StudentUIPostValidator>();
            services.AddTransient<IValidator<AttendanceRecordUI>, AttendanceRecordUIValidator>();
            services.AddBusinessLogic();
            services.AddDataAccess(Configuration.GetConnectionString("StudentDb"));
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniverApi v1"));
            }

            // app.UseHttpsRedirection();
            app.UseRouting();

            app.UseMiddleware<ErrorHendlingMidlewere>();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }
}