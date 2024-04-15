using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "AspNetUsers",
                newName: "NameSurnamee");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "AspNetUsers",
                newName: "ImageUrll");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameSurnamee",
                table: "AspNetUsers",
                newName: "NameSurname");

            migrationBuilder.RenameColumn(
                name: "ImageUrll",
                table: "AspNetUsers",
                newName: "ImageUrl");
        }
    }
}
