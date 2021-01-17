﻿// <auto-generated />
using DataProviderLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataProviderLayer.Migrations
{
    [DbContext(typeof(ExpertDbContext))]
    partial class ExpertDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DataProviderLayer.Entities.Heading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<string>("HeadingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HeadingType");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("MemberId");

                    b.HasKey("Id");

                    b.ToTable("Headings");
                });

            modelBuilder.Entity("DataProviderLayer.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("WebsiteUrl");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("DataProviderLayer.Entities.Heading", b =>
                {
                    b.HasOne("DataProviderLayer.Entities.Member", null)
                        .WithMany("Headings")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataProviderLayer.Entities.Member", b =>
                {
                    b.Navigation("Headings");
                });
#pragma warning restore 612, 618
        }
    }
}
