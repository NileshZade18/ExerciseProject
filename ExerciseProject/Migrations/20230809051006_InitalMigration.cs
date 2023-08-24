using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseProject.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "salaryDetailsDbSet",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFCcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaryDetailsDbSet", x => x.SalaryId);
                });

            migrationBuilder.CreateTable(
                name: "EpmloyeesDbSet",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    SalaryDetailSalaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpmloyeesDbSet", x => x.EmpID);
                    table.ForeignKey(
                        name: "FK_EpmloyeesDbSet_salaryDetailsDbSet_SalaryDetailSalaryId",
                        column: x => x.SalaryDetailSalaryId,
                        principalTable: "salaryDetailsDbSet",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpmloyeesDbSet_SalaryDetailSalaryId",
                table: "EpmloyeesDbSet",
                column: "SalaryDetailSalaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpmloyeesDbSet");

            migrationBuilder.DropTable(
                name: "salaryDetailsDbSet");
        }
    }
}
