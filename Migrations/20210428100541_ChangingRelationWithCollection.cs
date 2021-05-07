using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class ChangingRelationWithCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_education_tb_m_univeristy_UniversityID",
                table: "tb_m_education");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_profiling_tb_m_education_EducationID",
                table: "tb_m_profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_univeristy",
                table: "tb_m_univeristy");

            migrationBuilder.RenameTable(
                name: "tb_m_univeristy",
                newName: "tb_m_university");

            migrationBuilder.AlterColumn<int>(
                name: "EducationID",
                table: "tb_m_profiling",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UniversityID",
                table: "tb_m_education",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_university",
                table: "tb_m_university",
                column: "UniversityID");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_education_tb_m_university_UniversityID",
                table: "tb_m_education",
                column: "UniversityID",
                principalTable: "tb_m_university",
                principalColumn: "UniversityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_profiling_tb_m_education_EducationID",
                table: "tb_m_profiling",
                column: "EducationID",
                principalTable: "tb_m_education",
                principalColumn: "EducationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_education_tb_m_university_UniversityID",
                table: "tb_m_education");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_profiling_tb_m_education_EducationID",
                table: "tb_m_profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_university",
                table: "tb_m_university");

            migrationBuilder.RenameTable(
                name: "tb_m_university",
                newName: "tb_m_univeristy");

            migrationBuilder.AlterColumn<int>(
                name: "EducationID",
                table: "tb_m_profiling",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityID",
                table: "tb_m_education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_univeristy",
                table: "tb_m_univeristy",
                column: "UniversityID");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_education_tb_m_univeristy_UniversityID",
                table: "tb_m_education",
                column: "UniversityID",
                principalTable: "tb_m_univeristy",
                principalColumn: "UniversityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_profiling_tb_m_education_EducationID",
                table: "tb_m_profiling",
                column: "EducationID",
                principalTable: "tb_m_education",
                principalColumn: "EducationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
