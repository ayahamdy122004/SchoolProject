using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Departments_DID",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubID",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_SubID",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Ins_Subject_SubId",
                table: "Ins_Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentSubjects",
                table: "DepartmentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentSubjects_SubID",
                table: "DepartmentSubjects");

            migrationBuilder.RenameTable(
                name: "DepartmentSubjects",
                newName: "DepartmetSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                columns: new[] { "SubID", "StudID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject",
                columns: new[] { "SubId", "InsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects",
                columns: new[] { "SubID", "DID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudID",
                table: "StudentSubjects",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subject",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubjects_DID",
                table: "DepartmetSubjects",
                column: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Departments_DID",
                table: "DepartmetSubjects",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubID",
                table: "DepartmetSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Departments_DID",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubID",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudID",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmetSubjects_DID",
                table: "DepartmetSubjects");

            migrationBuilder.RenameTable(
                name: "DepartmetSubjects",
                newName: "DepartmentSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                columns: new[] { "StudID", "SubID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject",
                columns: new[] { "InsId", "SubId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentSubjects",
                table: "DepartmentSubjects",
                columns: new[] { "DID", "SubID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubID",
                table: "StudentSubjects",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_SubId",
                table: "Ins_Subject",
                column: "SubId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubjects_SubID",
                table: "DepartmentSubjects",
                column: "SubID");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Departments_DID",
                table: "DepartmentSubjects",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubID",
                table: "DepartmentSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID");
        }
    }
}
