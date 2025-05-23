using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace abulbarovakt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_departament",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Название кафедры"),
                    TeacherHeaderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_departament_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    c_teacher_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    c_teacher_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    f_department_id = table.Column<int>(type: "int4", nullable: false),
                    f_position_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.f_department_id,
                        principalTable: "cd_departament",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_position_id",
                        column: x => x.f_position_id,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_departament_TeacherHeaderId",
                table: "cd_departament",
                column: "TeacherHeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_c_position_id",
                table: "cd_teacher",
                column: "f_position_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_department_id",
                table: "cd_teacher",
                column: "f_department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_departament_cd_teacher_TeacherHeaderId",
                table: "cd_departament",
                column: "TeacherHeaderId",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_departament_cd_teacher_TeacherHeaderId",
                table: "cd_departament");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_departament");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
