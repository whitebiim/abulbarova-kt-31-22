
﻿using abulbarovakt_31_22.Database.Helper;
using abulbarovakt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace abulbarovakt_31_22.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(p => p.PositionId)
                   .HasName($"pk_{TableName}_position_id");
            // Автогенерация ID
            builder.Property(p => p.PositionId)
                    .ValueGeneratedOnAdd();
            // Настройка столбца ID
            builder.Property(p => p.PositionId)
                .HasColumnName("position_id")
                .HasComment("Идентификатор записи должности");


            // Настройка столбцов ID и название должности
            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }
}