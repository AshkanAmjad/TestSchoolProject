using Data.Profiles;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Extensions
{
    public static class MappingServiceExtensions
    {
        public static IServiceCollection AddMappingService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TeacherProfile));
            services.AddAutoMapper(typeof(TeacherCourseProfile));
            services.AddAutoMapper(typeof(CourseProfile));

            return services;
        }
    }
}
