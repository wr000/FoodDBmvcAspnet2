﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FoodDatabase.Models;

namespace FoodDatabase.Migrations
{
    [DbContext(typeof(FoodDatabaseContext))]
    [Migration("20181211223740_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodDatabase.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calories");

                    b.Property<decimal>("Protein");

                    b.Property<decimal>("Carbs");

                    b.Property<decimal>("Lipids");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("FoodItem");
                });
#pragma warning restore 612, 618
        }
    }
}
