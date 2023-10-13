using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcRepositoryPatternDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_info",
                columns: table => new
                {
                    username = table.Column<string>(name: "user_name", type: "varchar(10)", nullable: false),
                    userid = table.Column<long>(name: "user_id", type: "Bigint", nullable: false),
                    password = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_info", x => x.username);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_info");
        }
    }
}
