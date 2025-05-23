﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEST_EF.Models;

#nullable disable

namespace TEST_EF.Migrations
{
    [DbContext(typeof(RankenContext))]
    partial class RankenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");

                    b.HasData(
                        new
                        {
                            CoursesId = 1,
                            StudentsId = 1
                        },
                        new
                        {
                            CoursesId = 1,
                            StudentsId = 2
                        },
                        new
                        {
                            CoursesId = 1,
                            StudentsId = 3
                        },
                        new
                        {
                            CoursesId = 1,
                            StudentsId = 4
                        },
                        new
                        {
                            CoursesId = 2,
                            StudentsId = 1
                        },
                        new
                        {
                            CoursesId = 2,
                            StudentsId = 2
                        },
                        new
                        {
                            CoursesId = 2,
                            StudentsId = 3
                        });
                });

            modelBuilder.Entity("TEST_EF.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Physics"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Biology"
                        });
                });

            modelBuilder.Entity("TEST_EF.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FinancialAidStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FinancialAidStatus = "Passed",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            FinancialAidStatus = "Passed",
                            Name = "Jane Doe"
                        },
                        new
                        {
                            Id = 3,
                            FinancialAidStatus = "Passed",
                            Name = "Bobby Gibson"
                        },
                        new
                        {
                            Id = 4,
                            FinancialAidStatus = "Passed",
                            Name = "Chuck Noris"
                        });
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("TEST_EF.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEST_EF.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
