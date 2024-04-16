using Microsoft.EntityFrameworkCore.Migrations;
using NuGet.Packaging.Signing;

namespace Auctions.Data.Migrations
{
    public partial class Initialmgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "serial", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(450)", nullable: false),
                    Description = table.Column<string>(type: "varchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(450)", nullable: false),
                    IsSold = table.Column<bool>(type: "bool", nullable: false),
                    IdentityUserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    TimeOfClosure = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_Listings_Category_Id",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });





            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "serial", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IdentityUserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    ListingId = table.Column<int>(type: "serial", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "serial", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(450)", nullable: false),
                    IdentityUserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    ListingId = table.Column<int>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_IdentityUserId",
                table: "Bids",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ListingId",
                table: "Bids",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdentityUserId",
                table: "Comments",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ListingId",
                table: "Comments",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_IdentityUserId",
                table: "Listings",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryId", // Индекс для внешнего ключа
                table: "Listings",
                column: "CategoryId");

            migrationBuilder.InsertData(
            table: "Category",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "Техника" },
                { 2, "Винтаж" },
                { 3, "Искусство" },
                { 4, "Книги" },
                { 5, "Мода" },
                { 6, "Музыка" },
                { 7, "Антиквариат" }
            },
            columnTypes: new[] { "int", "varchar(450)" }
            ) ;

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Category");

        }
    }
}
