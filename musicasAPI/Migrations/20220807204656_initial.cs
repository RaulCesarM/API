using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musicasAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Singers",
                columns: table => new
                {
                    IdSinger = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singers", x => x.IdSinger);
                });

            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearRelease = table.Column<int>(type: "int", nullable: false),
                    UrlFrontcover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingerIdSinger = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albuns_Singers_SingerIdSinger",
                        column: x => x.SingerIdSinger,
                        principalTable: "Singers",
                        principalColumn: "IdSinger");
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    IdSong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingerIdSinger = table.Column<int>(type: "int", nullable: true),
                    AlbumIdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.IdSong);
                    table.ForeignKey(
                        name: "FK_Songs_Albuns_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Albuns",
                        principalColumn: "IdAlbum");
                    table.ForeignKey(
                        name: "FK_Songs_Singers_SingerIdSinger",
                        column: x => x.SingerIdSinger,
                        principalTable: "Singers",
                        principalColumn: "IdSinger");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albuns_SingerIdSinger",
                table: "Albuns",
                column: "SingerIdSinger");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumIdAlbum",
                table: "Songs",
                column: "AlbumIdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_SingerIdSinger",
                table: "Songs",
                column: "SingerIdSinger");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albuns");

            migrationBuilder.DropTable(
                name: "Singers");
        }
    }
}
