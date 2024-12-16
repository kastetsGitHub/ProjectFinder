﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Service.GitHubFinderAPI.Data;

#nullable disable

namespace Service.GitHubFinderAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241211170847_AddGitHubFinder")]
    partial class AddGitHubFinder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Service.GitHubFinderAPI.Models.GitHubFinder", b =>
                {
                    b.Property<string>("NameFinder")
                        .HasColumnType("text");

                    b.Property<string>("Repositories")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("NameFinder");

                    b.ToTable("GitHubFinders");
                });
#pragma warning restore 612, 618
        }
    }
}
