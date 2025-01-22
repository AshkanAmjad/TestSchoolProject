using Domain.Entities.Portal.Mapping;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Mapping;
using Domain.Entities.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class TestSchoolContext : DbContext
    {
        #region Constructor
        public TestSchoolContext(DbContextOptions<TestSchoolContext> options) : base(options)
        {

        }
        #endregion

        #region Tables
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TeacherCourse> TeachersCourse { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Maps
            modelBuilder.ApplyConfiguration(new TeacherMap());
            modelBuilder.ApplyConfiguration(new TeacherCourseMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            #endregion

            #region Filterings
            modelBuilder.Entity<Teacher>()
                        .HasQueryFilter(u => u.IsActived);

            modelBuilder.Entity<Course>()
                        .HasQueryFilter(d => d.IsActived);

            modelBuilder.Entity<TeacherCourse>()
                        .HasQueryFilter(d => d.IsActived);
            #endregion

            #region Seed data
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher()
                {
                    TeacherId = 1,
                    NationalCode = "0021765988",
                    FirstName="علی",
                    LastName ="فتحی",
                    Address = "تهران",
                    IsActived = true,
                    PhoneNumber="09123435566",
                    RegisterDate = DateTime.Now
                },
                new Teacher()
                {
                    TeacherId = 2,
                    NationalCode = "0031265777",
                    FirstName = "زهرا",
                    LastName = "مقدسی",
                    RegisterDate = DateTime.Now,
                    PhoneNumber = "09354567688",
                    Address = "کرج",
                    IsActived = true
                },
                new Teacher()
                {
                    TeacherId=3,
                    NationalCode ="007545667",
                    Address ="تهران",
                    IsActived = true,
                    RegisterDate= DateTime.Now,
                    FirstName = "محمد",
                    LastName = "محمدی",
                    PhoneNumber ="09124546677"
                });

            modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                   CourseId = 1,
                   Title = "فیزیک",
                   IsActived= true,
                   RegisterDate =DateTime.Now
                },
                new Course()
                { 
                   CourseId= 2,
                   Title = "ریاضی",
                   IsActived= true,
                   RegisterDate = DateTime.Now
                });

            modelBuilder.Entity<TeacherCourse>().HasData(
                new TeacherCourse()
                {
                    TeacherCourseId = 1,
                    CourseId = 1,
                    TeacherId =1,
                    IsActived = true,
                    RegisterDate = DateTime.Now
                },
                new TeacherCourse()
                {
                    TeacherCourseId =2,
                    CourseId = 2,
                    TeacherId =2,
                    IsActived=true,
                    RegisterDate = DateTime.Now
                }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
