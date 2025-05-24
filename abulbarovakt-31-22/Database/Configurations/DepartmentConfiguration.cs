
﻿using abulbarovakt_31_22.Database.Helper;
using abulbarovakt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace abulbarovakt_31_22.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_departament";

        public void Configure(EntityTypeBuilder<Department> builder)
        { // Настройка первичного ключа
            builder.HasKey(p => p.DepartmentId)
                   .HasName($"pk_{TableName}_department_id");
            // Автогенерация ID
            builder.Property(p => p.DepartmentId)
                    .ValueGeneratedOnAdd();
            // Настройка столбца ID
            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи кафедры");


            // Настройка связи с Teacher (один-к-одному)
            builder.HasOne(d => d.Teacher)
              .WithOne()
              .HasForeignKey<Department>(t => t.TeacherHeaderId)
              .OnDelete(DeleteBehavior.Cascade); //каскадное удаление 


            // Настройка столбца названия кафедры
            builder.Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название кафедры");


           // Указание имени таблицы
            builder.ToTable(TableName);
        }
    }
}