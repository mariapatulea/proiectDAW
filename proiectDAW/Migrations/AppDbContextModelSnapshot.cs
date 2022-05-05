﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proiectDAW.Models;

namespace proiectDAW.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("proiectDAW.Models.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHardcover")
                        .HasColumnType("bit");

                    b.Property<int>("NumarPagini")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Editor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishingHouse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editors");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reader");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.ReaderBook", b =>
                {
                    b.Property<int>("ReaderId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("ReaderId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("ReaderBook");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Book", b =>
                {
                    b.HasOne("proiectDAW.Models.Entities.Author", "Author")
                        .WithMany("PublishedBooks")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Editor", b =>
                {
                    b.HasOne("proiectDAW.Models.Entities.Author", "Author")
                        .WithOne("Editor")
                        .HasForeignKey("proiectDAW.Models.Entities.Editor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.ReaderBook", b =>
                {
                    b.HasOne("proiectDAW.Models.Entities.Book", "Book")
                        .WithMany("ReaderBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proiectDAW.Models.Entities.Reader", "Reader")
                        .WithMany("ReaderBooks")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Author", b =>
                {
                    b.Navigation("Editor");

                    b.Navigation("PublishedBooks");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Book", b =>
                {
                    b.Navigation("ReaderBooks");
                });

            modelBuilder.Entity("proiectDAW.Models.Entities.Reader", b =>
                {
                    b.Navigation("ReaderBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
