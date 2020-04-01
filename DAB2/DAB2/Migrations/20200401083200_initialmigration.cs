using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB2.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HelpRequestModel",
                columns: table => new
                {
                    HelpRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentAuId = table.Column<int>(nullable: true),
                    teacherAuId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    AssignmentId = table.Column<int>(nullable: true),
                    exerciseNumber = table.Column<int>(nullable: true),
                    exerciseLecture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpRequestModel", x => x.HelpRequestId);
                    table.ForeignKey(
                        name: "FK_HelpRequestModel_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpRequestModel_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpRequestModel_Students_studentAuId",
                        column: x => x.studentAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpRequestModel_Teachers_teacherAuId",
                        column: x => x.teacherAuId,
                        principalTable: "Teachers",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HelpRequestModel_Exercises_exerciseNumber_exerciseLecture",
                        columns: x => new { x.exerciseNumber, x.exerciseLecture },
                        principalTable: "Exercises",
                        principalColumns: new[] { "Number", "Lecture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequestModel_AssignmentId",
                table: "HelpRequestModel",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequestModel_CourseId",
                table: "HelpRequestModel",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequestModel_studentAuId",
                table: "HelpRequestModel",
                column: "studentAuId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequestModel_teacherAuId",
                table: "HelpRequestModel",
                column: "teacherAuId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequestModel_exerciseNumber_exerciseLecture",
                table: "HelpRequestModel",
                columns: new[] { "exerciseNumber", "exerciseLecture" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpRequestModel");
        }
    }
}
