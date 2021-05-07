﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Context;

namespace UserManagement.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210503044327_AccountRoleModelInvalidStringNIK")]
    partial class AccountRoleModelInvalidStringNIK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserManagement.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_account");
                });

            modelBuilder.Entity("UserManagement.Models.AccountRole", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("NIK", "RoleID");

                    b.HasIndex("RoleID");

                    b.ToTable("AccountRoles");
                });

            modelBuilder.Entity("UserManagement.Models.Education", b =>
                {
                    b.Property<int>("EducationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityID")
                        .HasColumnType("int");

                    b.HasKey("EducationID");

                    b.HasIndex("UniversityID");

                    b.ToTable("tb_m_education");
                });

            modelBuilder.Entity("UserManagement.Models.Person", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_persons");
                });

            modelBuilder.Entity("UserManagement.Models.Profiling", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EducationID")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("EducationID");

                    b.ToTable("tb_m_profiling");
                });

            modelBuilder.Entity("UserManagement.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("UserManagement.Models.University", b =>
                {
                    b.Property<int>("UniversityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniversityID");

                    b.ToTable("tb_m_university");
                });

            modelBuilder.Entity("UserManagement.Models.Account", b =>
                {
                    b.HasOne("UserManagement.Models.Person", "Person")
                        .WithOne("Account")
                        .HasForeignKey("UserManagement.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UserManagement.Models.AccountRole", b =>
                {
                    b.HasOne("UserManagement.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagement.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UserManagement.Models.Education", b =>
                {
                    b.HasOne("UserManagement.Models.University", "University")
                        .WithMany("Education")
                        .HasForeignKey("UniversityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("UserManagement.Models.Profiling", b =>
                {
                    b.HasOne("UserManagement.Models.Education", "Education")
                        .WithMany("Profiling")
                        .HasForeignKey("EducationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagement.Models.Account", "Account")
                        .WithOne("Profiling")
                        .HasForeignKey("UserManagement.Models.Profiling", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Education");
                });

            modelBuilder.Entity("UserManagement.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");

                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("UserManagement.Models.Education", b =>
                {
                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("UserManagement.Models.Person", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("UserManagement.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("UserManagement.Models.University", b =>
                {
                    b.Navigation("Education");
                });
#pragma warning restore 612, 618
        }
    }
}
