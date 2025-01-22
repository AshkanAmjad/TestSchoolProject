using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Portal");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Portal",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "Security",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                schema: "Portal",
                columns: table => new
                {
                    TeacherCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.TeacherCourseId);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Portal",
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Security",
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Portal",
                table: "Courses",
                columns: new[] { "CourseId", "IsActived", "RegisterDate", "Title" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 1, 22, 23, 1, 21, 313, DateTimeKind.Local).AddTicks(9524), "فیزیک" },
                    { 2, true, new DateTime(2025, 1, 22, 23, 1, 21, 313, DateTimeKind.Local).AddTicks(9525), "ریاضی" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Teachers",
                columns: new[] { "TeacherId", "Address", "FirstName", "IsActived", "LastName", "NationalCode", "PhoneNumber", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "تهران", "علی", true, "فتحی", "0021765988", "09123435566", new DateTime(2025, 1, 22, 23, 1, 21, 313, DateTimeKind.Local).AddTicks(9387) },
                    { 2, "کرج", "زهرا", true, "مقدسی", "0031265777", "09354567688", new DateTime(2025, 1, 22, 23, 1, 21, 313, DateTimeKind.Local).AddTicks(9401) },
                    { 3, "تهران", "محمد", true, "محمدی", "007545667", "09124546677", new DateTime(2025, 1, 22, 23, 1, 21, 313, DateTimeKind.Local).AddTicks(9403) }
                });

            migrationBuilder.InsertData(
                schema: "Portal",
                table: "TeacherCourses",
                columns: new[] { "TeacherCourseId", "CourseId", "IsActived", "RegisterDate", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2025, 1, 22, 23, 1, 21, 313, DateTimeKind.Local).AddTicks(9535), 1 },
                    { 2, 2, true, new DateTime(2025, 1, 22, 23, 1, 21, 313, DateTimeKind.Local).AddTicks(9538), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseId",
                schema: "Portal",
                table: "TeacherCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                schema: "Portal",
                table: "TeacherCourses",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCourses",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "Security");
        }
    }
}
