﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlatformDemo.DAL.Data;

#nullable disable

namespace PlatformDemo.DAL.Migrations
{
    [DbContext(typeof(PlatformDbContext))]
    [Migration("20241007212232_UpdatedCascadeDelete")]
    partial class UpdatedCascadeDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlatformDemo.DAL.Model.ServicePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ServicePlans");
                });

            modelBuilder.Entity("PlatformDemo.DAL.Model.TimeSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServicePlanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServicePlanId");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("PlatformDemo.DAL.Model.TimeSheet", b =>
                {
                    b.HasOne("PlatformDemo.DAL.Model.ServicePlan", "ServicePlan")
                        .WithMany("TimeSheets")
                        .HasForeignKey("ServicePlanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ServicePlan");
                });

            modelBuilder.Entity("PlatformDemo.DAL.Model.ServicePlan", b =>
                {
                    b.Navigation("TimeSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
