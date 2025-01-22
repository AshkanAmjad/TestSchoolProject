
using Application.Services.Implements;
using Application.Services.Interfaces;
using Data.Context;
using Data.Profiles;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestSchool.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
            builder.Services.AddDbContext<TestSchoolContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            #endregion

            #region Life Time
            builder.Services.AddScoped<ITeacherCourseRepository, TeacherCourseRepository>();
            builder.Services.AddScoped<ITeacherCourseService, TeacherCourseService>();
            #endregion

            #region Mapper
            builder.Services.AddAutoMapper(typeof(TeacherProfile));
            builder.Services.AddAutoMapper(typeof(TeacherCourseProfile));
            builder.Services.AddAutoMapper(typeof(CourseProfile));
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
