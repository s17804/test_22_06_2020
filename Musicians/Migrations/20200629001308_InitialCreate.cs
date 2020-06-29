using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicians.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.IdMusician);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MusicLabelIdMusicLabel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albums_MusicLabels_MusicLabelIdMusicLabel",
                        column: x => x.MusicLabelIdMusicLabel,
                        principalTable: "MusicLabels",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    AlbumIdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicianTracks",
                columns: table => new
                {
                    IdMusicianTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicianIdMusician = table.Column<int>(type: "int", nullable: true),
                    TrackIdTrack = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianTracks", x => x.IdMusicianTrack);
                    table.ForeignKey(
                        name: "FK_MusicianTracks_Musicians_MusicianIdMusician",
                        column: x => x.MusicianIdMusician,
                        principalTable: "Musicians",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicianTracks_Tracks_TrackIdTrack",
                        column: x => x.TrackIdTrack,
                        principalTable: "Tracks",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MusicLabelIdMusicLabel",
                table: "Albums",
                column: "MusicLabelIdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTracks_MusicianIdMusician",
                table: "MusicianTracks",
                column: "MusicianIdMusician");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTracks_TrackIdTrack",
                table: "MusicianTracks",
                column: "TrackIdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumIdAlbum",
                table: "Tracks",
                column: "AlbumIdAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianTracks");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "MusicLabels");
        }
    }
}
