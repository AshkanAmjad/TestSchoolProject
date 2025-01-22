using Domain.Entities.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Security.Mapping
{
    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId);

            builder.Property(t => t.FirstName)
                   .IsRequired();

            builder.Property(t => t.LastName)
                   .IsRequired();

            builder.Property(u => u.Address)
                   .IsRequired();

            builder.Property(t => t.PhoneNumber)
                   .IsRequired();

            builder.Property(u => u.IsActived)
                   .IsRequired();

            builder.Property(u => u.RegisterDate)
                   .IsRequired();
        }
    }
}
