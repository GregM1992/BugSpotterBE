using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugSpotterBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Favorite = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Likes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SuggestionContent = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Agrees = table.Column<int>(type: "integer", nullable: false),
                    Disagrees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    CollectionId = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Favorite = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "Favorite", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, true, "First Collection", 1 },
                    { 2, true, "Bugs found on vacation", 2 },
                    { 3, false, "Jumping Spiders", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "Likes", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Wow! This one is so cool!", 3, 1, 1 },
                    { 2, "NEAT!", 2, 2, 2 },
                    { 3, "EWWWWWWW", 8, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "Agrees", "Disagrees", "PostId", "SuggestionContent", "UserId" },
                values: new object[,]
                {
                    { 1, 9, 4, 1, "Phiddipus Audax", 2 },
                    { 2, 2, 0, 2, "Praying Mantis", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagType" },
                values: new object[,]
                {
                    { 1, "Looking for Identification" },
                    { 2, "Casual Observation" },
                    { 3, "Scientific Study" },
                    { 4, "Educational Purpose" },
                    { 5, "Curiosity" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "City", "EmailAddress", "State", "Uid", "UserName" },
                values: new object[,]
                {
                    { 1, "I love jumping spiders!", "Madison", "gGroks92@gmail.com", "Tennessee", "npm6sXBQ5nNCjt7upw1S7NRamLd2", "oopsAllSpiders" },
                    { 2, "this is a test user", "Darujhistan", "testEmail@gmail.com", "Seven Cities", "", "notAUser" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CollectionId", "Description", "Favorite", "Image", "Latitude", "Longitude", "TagId", "UserId" },
                values: new object[,]
                {
                    { 1, 3, "Found this lil guy on the tree in my backyard!", true, "https://www.planetnatural.com/wp-content/uploads/2023/12/Jumping-Spider.jpg", 36.2562, -86.714399999999998, 1, 1 },
                    { 2, 1, "Almost ran over this one!", false, "https://www.reconnectwithnature.org/getmedia/1d82fb8d-2743-463f-b5e4-f873f2583a7b/Praying-Mantis-Sugar-Creek-Preserve-Glenn_P_Knoblock-July-2022_9307.JPG?width=1500&height=1000&ext=.jpg", 36.015617800000001, -86.581939399999996, 2, 2 },
                    { 3, 3, "Such pretty colors!", true, "https://assets2.cbsnewsstatic.com/hub/i/r/2016/06/07/cecfc35f-944e-4d79-a270-59e988507ed5/thumbnail/640x483/620c2bcfde9748fd2f23578b09279947/rtsg6uy.jpg?v=1d6c78a71b7b6252b543a329b3a5744d", 36.177120000000002, -86.750510000000006, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CollectionId",
                table: "Posts",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TagId",
                table: "Posts",
                column: "TagId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
