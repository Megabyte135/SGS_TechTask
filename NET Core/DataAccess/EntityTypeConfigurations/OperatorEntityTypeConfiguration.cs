using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityTypeConfigurations
{
    internal class OperatorEntityTypeConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id).HasName("PK__operator__3213E83F14860590");

            modelBuilder.ToTable("operators");

            modelBuilder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            modelBuilder.Property(e => e.FullName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("full_name");
        }

    }
}
