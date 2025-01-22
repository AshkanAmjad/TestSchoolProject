using Domain.Entities.Portal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Portal.Mapping
{
    public class TeacherCourseMap : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.HasKey(tc => tc.TeacherCourseId);

            builder.Property(tc => tc.CourseId)
                   .IsRequired();

            builder.Property(tc => tc.TeacherId)
                   .IsRequired();

            builder.Property(tc => tc.IsActived)
                   .IsRequired();

            builder.Property(tc => tc.RegisterDate)
                   .IsRequired();

            builder.HasOne(tc => tc.Course)
                   .WithMany(c => c.UserCourses)
                   .HasForeignKey(tc => tc.CourseId);

            builder.HasOne(tc => tc.Teacher)
                   .WithMany(t => t.UserCourses)
                   .HasForeignKey(tc => tc.TeacherId);

        }
    }
}
