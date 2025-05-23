﻿using abulbarovakt_31_22.Database.Helper;
using abulbarovakt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace abulbarovakt_31_22.Database.Configurations
{
    public class TeachersConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
              .HasKey(t => t.TeachersId)
              .HasName($"pk_{TableName}_teacher_id");

            builder.Property(t => t.TeachersId)
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.TeachersId)
              .HasColumnName("teacher_id")
              .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
              .IsRequired()
              .HasColumnName("c_teacher_firstname")
              .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.LastName)
              .IsRequired()
              .HasColumnName("c_teacher_lastname")
              .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_teacher_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.DepartmentId)
              .IsRequired()
              .HasColumnName("f_department_id")
              .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
              .HasOne(p => p.Department)
              .WithMany()
              .HasForeignKey(p => p.DepartmentId)
              .HasConstraintName("fk_f_department_id")
              .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
              .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_f_department_id");

            builder.Navigation(p => p.Department)
              .AutoInclude();

            builder.Property(p => p.PositionId)
              .IsRequired()
              .HasColumnName("f_position_id")
              .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
              .HasOne(p => p.Position)
              .WithMany()
              .HasForeignKey(p => p.PositionId)
              .HasConstraintName("fk_f_position_id")
              .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
              .HasIndex(p => p.PositionId, $"idx_{TableName}_fk_c_position_id");

            builder.Navigation(p => p.Position)
              .AutoInclude();
        }
    }
}