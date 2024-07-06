using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityTypeConfigurations
{
    internal class OperationEntityTypeConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id).HasName("PK__operatio__3213E83FBB0F75B0");

            modelBuilder.ToTable("operations");

            modelBuilder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            modelBuilder.Property(e => e.ContainerId)
                .HasColumnName("container_id");
            modelBuilder.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            modelBuilder.Property(e => e.InspectionPlace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("inspection_place");
            modelBuilder.Property(e => e.OperatorId).HasColumnName("operator_id");
            modelBuilder.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            modelBuilder.Property(e => e.Type)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");

            modelBuilder.HasOne(d => d.Container)
                .WithMany(p => p.Operations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(d => d.ContainerId)
                .HasConstraintName("FK__operation__conta__6A30C649");

            modelBuilder.HasOne(d => d.Operator)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.OperatorId)
                .HasConstraintName("FK__operation__opera__6B24EA82");
        }

    }
}
