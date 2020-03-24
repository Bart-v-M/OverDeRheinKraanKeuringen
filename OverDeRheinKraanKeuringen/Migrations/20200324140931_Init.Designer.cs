﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OverDeRheinKraanKeuringen.Data;

namespace OverDeRheinKraanKeuringen.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200324140931_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OverDeRheinKraanKeuringen.Models.AssignmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CableSupplier")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("OperatingHours")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Signature")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("WorkInstruction")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("OverDeRheinKraanKeuringen.Models.CableChecklistModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssignmentModelId")
                        .HasColumnType("int");

                    b.Property<int>("Breakage_30D")
                        .HasColumnType("int");

                    b.Property<int>("Breakage_6D")
                        .HasColumnType("int");

                    b.Property<int>("DamageCorrosion")
                        .HasColumnType("int");

                    b.Property<int>("DamageOutside")
                        .HasColumnType("int");

                    b.Property<int>("DamageTotal")
                        .HasColumnType("int");

                    b.Property<int>("PositionMeasuringPoints")
                        .HasColumnType("int");

                    b.Property<int>("ReducedCableDiameter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentModelId");

                    b.ToTable("cableCheckLists");
                });

            modelBuilder.Entity("OverDeRheinKraanKeuringen.Models.DamageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CableChecklistModelId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CableChecklistModelId");

                    b.ToTable("damageTypes");
                });

            modelBuilder.Entity("OverDeRheinKraanKeuringen.Models.CableChecklistModel", b =>
                {
                    b.HasOne("OverDeRheinKraanKeuringen.Models.AssignmentModel", null)
                        .WithMany("cableChecklists")
                        .HasForeignKey("AssignmentModelId");
                });

            modelBuilder.Entity("OverDeRheinKraanKeuringen.Models.DamageType", b =>
                {
                    b.HasOne("OverDeRheinKraanKeuringen.Models.CableChecklistModel", null)
                        .WithMany("DamageTypes")
                        .HasForeignKey("CableChecklistModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
