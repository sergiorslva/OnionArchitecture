using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));

            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Name).HasMaxLength(80);

            builder.Property(t => t.Email).HasMaxLength(80);

            builder.Property(t => t.Phone).HasMaxLength(20);

            builder.Property(t => t.StudentLevel)
                .HasConversion(v => v.ToString(),
                v => (StudentLevelEnum)Enum.Parse(typeof(StudentLevelEnum), v));
        }
    }
}
