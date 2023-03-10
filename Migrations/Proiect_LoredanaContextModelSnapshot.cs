// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Loredana.Data;

#nullable disable

namespace Proiect_Loredana.Migrations
{
    [DbContext(typeof(Proiect_LoredanaContext))]
    partial class Proiect_LoredanaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Loredana.Models.Acquisition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("GameID");

                    b.ToTable("Acquisition");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.GameCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("GameID");

                    b.ToTable("GameCategory");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Acquisition", b =>
                {
                    b.HasOne("Proiect_Loredana.Models.Client", "Client")
                        .WithMany("Acquisitions")
                        .HasForeignKey("ClientID");

                    b.HasOne("Proiect_Loredana.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID");

                    b.Navigation("Client");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Game", b =>
                {
                    b.HasOne("Proiect_Loredana.Models.Author", "Author")
                        .WithMany("Games")
                        .HasForeignKey("AuthorID");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.GameCategory", b =>
                {
                    b.HasOne("Proiect_Loredana.Models.Category", "Category")
                        .WithMany("GameCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Loredana.Models.Game", "Game")
                        .WithMany("GameCategories")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Author", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Category", b =>
                {
                    b.Navigation("GameCategories");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Client", b =>
                {
                    b.Navigation("Acquisitions");
                });

            modelBuilder.Entity("Proiect_Loredana.Models.Game", b =>
                {
                    b.Navigation("GameCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
