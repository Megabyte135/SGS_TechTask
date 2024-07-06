using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityTypeConfigurations
{
    internal class ContainerEntityTypeConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> modelBuilder)
        {
            modelBuilder
                    .HasKey(e => e.Id)
                    .HasName("PK__containe__3213E83FA59E838C");

            modelBuilder
                    .ToTable("containers");

            modelBuilder
                    .Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
            modelBuilder
                    .Property(e => e.Empty)
                    .HasColumnName("empty");
            modelBuilder
                    .Property(e => e.Length)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("length");
            modelBuilder
                    .Property(e => e.Number)
                    .HasColumnName("number");
            modelBuilder
                    .Property(e => e.ReceiptionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("receiption_date");
            modelBuilder.Property(e => e.Type)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("type");
            modelBuilder.Property(e => e.Weight)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("weight");
            modelBuilder.Property(e => e.Width)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("width");
        }

    }
}
