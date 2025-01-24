using Application.Services.Implements;
using Application.Services.Interfaces;
using Data.Repositories;
using Domain.Interfaces;

namespace TestSchool.Api.Dependencies
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Life Time
            services.AddScoped<ITeacherCourseRepository, TeacherCourseRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            //-------------------------------------------------------------------------------

            services.AddScoped<ITeacherCourseService, TeacherCourseService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseSevice>();
            #endregion
        }
    }
}
