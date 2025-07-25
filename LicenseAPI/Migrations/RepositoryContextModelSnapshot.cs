﻿// <auto-generated />
using LicenseAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LicenseAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.7");

            modelBuilder.Entity("LicenseAPI.License", b =>
                {
                    b.Property<string>("MachineID")
                        .HasColumnType("TEXT");

                    b.Property<string>("LicenseKey")
                        .HasColumnType("TEXT");

                    b.HasKey("MachineID");

                    b.ToTable("Licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
