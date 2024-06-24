﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonApi.Data;

#nullable disable

namespace PersonApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240619102635_ChangeDateOfBirthToAge")]
    partial class ChangeDateOfBirthToAge
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonApi.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 23,
                            Name = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            Age = 18,
                            Name = "Foo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
