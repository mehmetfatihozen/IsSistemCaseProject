﻿// <auto-generated />
using System;
using IsSistemCase.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IsSistemCase.Repository.Migrations
{
    [DbContext(typeof(IsSistemSqlDbContext))]
    [Migration("20231009142751_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IsSistemCase.Core.Models.DbEntities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("IsSistemCase.Core.Models.DbEntities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("NumberOfGuests")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations", (string)null);
                });

            modelBuilder.Entity("IsSistemCase.Core.Models.DbEntities.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Capacity")
                        .HasColumnType("tinyint");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6d74bbd2-bfcb-44fe-8086-01efb1118528"),
                            Capacity = (byte)2,
                            Number = 1
                        },
                        new
                        {
                            Id = new Guid("0e1bb2c3-9ef3-4407-8fbf-98d2ad4df840"),
                            Capacity = (byte)2,
                            Number = 2
                        },
                        new
                        {
                            Id = new Guid("28d7d36b-d483-40af-8c2c-c862e013d4f7"),
                            Capacity = (byte)2,
                            Number = 3
                        },
                        new
                        {
                            Id = new Guid("f1d872db-e222-4bd8-aed5-ebaa5905666c"),
                            Capacity = (byte)2,
                            Number = 4
                        },
                        new
                        {
                            Id = new Guid("fe398cc0-36a6-49c8-9337-7e9149455c03"),
                            Capacity = (byte)2,
                            Number = 5
                        },
                        new
                        {
                            Id = new Guid("7da6cfe4-aa43-4124-99ff-a69918a753ea"),
                            Capacity = (byte)2,
                            Number = 6
                        },
                        new
                        {
                            Id = new Guid("1514ff63-2ebb-4f6d-82f5-9e866a5c38b4"),
                            Capacity = (byte)4,
                            Number = 7
                        },
                        new
                        {
                            Id = new Guid("19d61eeb-34c8-4c14-9965-74f0b7db0570"),
                            Capacity = (byte)4,
                            Number = 8
                        },
                        new
                        {
                            Id = new Guid("ec47278b-b3e6-41b5-85af-a2a12b14a203"),
                            Capacity = (byte)4,
                            Number = 9
                        },
                        new
                        {
                            Id = new Guid("ba5eff4f-b4fb-4966-b473-b70e71d35832"),
                            Capacity = (byte)4,
                            Number = 10
                        },
                        new
                        {
                            Id = new Guid("68bae558-1968-41e0-99cb-68a3b7fe9acc"),
                            Capacity = (byte)4,
                            Number = 11
                        },
                        new
                        {
                            Id = new Guid("5a1e4378-0f07-4475-93da-f341d4e50b86"),
                            Capacity = (byte)4,
                            Number = 12
                        },
                        new
                        {
                            Id = new Guid("ad6aaa16-d30a-455a-8ad0-545767d74c7d"),
                            Capacity = (byte)4,
                            Number = 13
                        },
                        new
                        {
                            Id = new Guid("a56b414c-e394-42f5-b9cd-0b8d7898fb06"),
                            Capacity = (byte)4,
                            Number = 14
                        },
                        new
                        {
                            Id = new Guid("8aa250d7-37a5-4ae6-a5bb-6d27d179f036"),
                            Capacity = (byte)4,
                            Number = 15
                        },
                        new
                        {
                            Id = new Guid("ecca94c1-659e-4982-876d-262af6b279b2"),
                            Capacity = (byte)4,
                            Number = 16
                        },
                        new
                        {
                            Id = new Guid("f9799ff7-c51c-4347-a09e-4751dd4ee2cf"),
                            Capacity = (byte)6,
                            Number = 17
                        },
                        new
                        {
                            Id = new Guid("a93d467c-18bd-48fd-84ad-b7f9a9788d52"),
                            Capacity = (byte)6,
                            Number = 18
                        },
                        new
                        {
                            Id = new Guid("1eb1a6ab-5ded-416b-ac0e-8e47a1d85f2d"),
                            Capacity = (byte)8,
                            Number = 19
                        },
                        new
                        {
                            Id = new Guid("6e8f97c5-f786-41ea-be75-065e7d0d4fa6"),
                            Capacity = (byte)8,
                            Number = 20
                        });
                });

            modelBuilder.Entity("IsSistemCase.Core.Models.DbEntities.Reservation", b =>
                {
                    b.HasOne("IsSistemCase.Core.Models.DbEntities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsSistemCase.Core.Models.DbEntities.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("IsSistemCase.Core.Models.DbEntities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("IsSistemCase.Core.Models.DbEntities.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
