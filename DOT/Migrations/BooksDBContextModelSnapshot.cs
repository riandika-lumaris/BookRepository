﻿// <auto-generated />
using System;
using DOT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DOT.Migrations
{
    [DbContext(typeof(BooksDBContext))]
    partial class BooksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("DOT.Core.Author", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = new Guid("9e6e6f5b-4e1d-43ed-aae7-69617ba2a8b6"),
                            Name = "JK Rowling"
                        },
                        new
                        {
                            ID = new Guid("4ef1735e-a2a6-4fe4-bab6-39d3e5d38d92"),
                            Name = "Agatha Christie"
                        });
                });

            modelBuilder.Entity("DOT.Core.Book", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = new Guid("14c631b0-c96a-4bfa-8905-875b0111fd35"),
                            AuthorID = new Guid("9e6e6f5b-4e1d-43ed-aae7-69617ba2a8b6"),
                            Title = "Harry Potter"
                        },
                        new
                        {
                            ID = new Guid("68bf8b1f-6381-42da-95c4-fc6ce2d0af9a"),
                            AuthorID = new Guid("4ef1735e-a2a6-4fe4-bab6-39d3e5d38d92"),
                            Title = "Murder on the Orient Express"
                        });
                });

            modelBuilder.Entity("DOT.Core.Book", b =>
                {
                    b.HasOne("DOT.Core.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });
#pragma warning restore 612, 618
        }
    }
}