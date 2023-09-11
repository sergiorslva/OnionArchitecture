using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(nameof(Teacher));

            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Name).HasMaxLength(80);

            builder.Property(t => t.Email).HasMaxLength(80);

            builder.Property(t => t.Phone).HasMaxLength(20);
        }
    }
}
