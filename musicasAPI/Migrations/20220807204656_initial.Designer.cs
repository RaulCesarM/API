﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using musicasAPI.Contexts;

#nullable disable

namespace musicasAPI.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20220807204656_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("musicasAPI.Models.v2.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlbum"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SingerIdSinger")
                        .HasColumnType("int");

                    b.Property<string>("UrlFrontcover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearRelease")
                        .HasColumnType("int");

                    b.HasKey("IdAlbum");

                    b.HasIndex("SingerIdSinger");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("musicasAPI.Models.v2.Singer", b =>
                {
                    b.Property<int>("IdSinger")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSinger"), 1L, 1);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSinger");

                    b.ToTable("Singers");
                });

            modelBuilder.Entity("musicasAPI.Models.v2.Song", b =>
                {
                    b.Property<int>("IdSong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSong"), 1L, 1);

                    b.Property<int?>("AlbumIdAlbum")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SingerIdSinger")
                        .HasColumnType("int");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSong");

                    b.HasIndex("AlbumIdAlbum");

                    b.HasIndex("SingerIdSinger");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("musicasAPI.Models.v2.Album", b =>
                {
                    b.HasOne("musicasAPI.Models.v2.Singer", "Singer")
                        .WithMany("Albuns")
                        .HasForeignKey("SingerIdSinger");

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("musicasAPI.Models.v2.Song", b =>
                {
                    b.HasOne("musicasAPI.Models.v2.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumIdAlbum");

                    b.HasOne("musicasAPI.Models.v2.Singer", "Singer")
                        .WithMany("Songs")
                        .HasForeignKey("SingerIdSinger");

                    b.Navigation("Album");

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("musicasAPI.Models.v2.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("musicasAPI.Models.v2.Singer", b =>
                {
                    b.Navigation("Albuns");

                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
