using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTickets.Data.Migrations
{
    public partial class addedQuantityToProductsInShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TicketsInShoppingCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TicketsInShoppingCart");
        }
    }
}
