using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VeMayBays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoHieuChuyenBay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiemDen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaVe = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeMayBays", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeMayBays");
        }
    }
}
