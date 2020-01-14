﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhenixProject.Data;

namespace PhenixProject.Migrations
{
    [DbContext(typeof(AppIdentityDbContext))]
    [Migration("20200114103140__links_and_skills")]
    partial class _links_and_skills
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PhenixProject.Data.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("PhenixProject.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Photo");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PhenixProject.Entities.CandidateInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("CareerObjective");

                    b.Property<string>("City");

                    b.Property<string>("DesiredSalary");

                    b.Property<int>("Employment");

                    b.HasKey("Id");

                    b.ToTable("CandidateInfos");
                });

            modelBuilder.Entity("PhenixProject.Entities.Contacts.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PhenixProject.Entities.Contacts.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("PhenixProject.Entities.Contacts.MemberContacts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid?>("EmailId");

                    b.Property<Guid?>("PhoneId");

                    b.Property<Guid?>("SecondPhoneId");

                    b.Property<Guid?>("SkypeId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("EmailId");

                    b.HasIndex("PhoneId");

                    b.HasIndex("SecondPhoneId");

                    b.HasIndex("SkypeId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PhenixProject.Entities.Contacts.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("PhenixProject.Entities.Contacts.Skype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Skypes");
                });

            modelBuilder.Entity("PhenixProject.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("OfficeId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("PhenixProject.Entities.EmployeeHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Event");

                    b.HasKey("Id");

                    b.ToTable("EmployeeHistories");
                });

            modelBuilder.Entity("PhenixProject.Entities.EmployeeInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DepartmentId");

                    b.Property<Guid?>("HistoryId");

                    b.Property<Guid?>("OfficeId");

                    b.Property<Guid?>("PayrollId");

                    b.Property<Guid?>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("HistoryId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PayrollId");

                    b.HasIndex("PositionId");

                    b.ToTable("EmployeeInfos");
                });

            modelBuilder.Entity("PhenixProject.Entities.Information.EducationInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CandidateInfoId");

                    b.Property<string>("Education");

                    b.Property<string>("EducationalInstitution");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Faculty");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CandidateInfoId");

                    b.ToTable("EducationInfos");
                });

            modelBuilder.Entity("PhenixProject.Entities.Information.WorkInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<Guid?>("CandidateInfoId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Position");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CandidateInfoId");

                    b.ToTable("WorkInfos");
                });

            modelBuilder.Entity("PhenixProject.Entities.Leave", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("EmployeeInfoId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<decimal>("TotalDays");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("PhenixProject.Entities.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("EmployeeInfoId");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("PhenixProject.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CandidateInfoId");

                    b.Property<Guid?>("EmployeeInfoId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsCandidate");

                    b.Property<bool>("IsEmployee");

                    b.Property<Guid?>("OfficeId");

                    b.Property<Guid?>("PersonalInfoId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateInfoId");

                    b.HasIndex("EmployeeInfoId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("PhenixProject.Entities.Office", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("PhenixProject.Entities.Payroll", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Currency");

                    b.Property<int>("Employment");

                    b.Property<decimal>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("PhenixProject.Entities.PersonalInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<Guid?>("ContactsId");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("MidName");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.HasIndex("ContactsId");

                    b.ToTable("PersonalInfos");
                });

            modelBuilder.Entity("PhenixProject.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DepartmentId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("PhenixProject.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("EmployeeInfoId");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("PhenixProject.Data.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PhenixProject.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PhenixProject.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("PhenixProject.Data.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhenixProject.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PhenixProject.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhenixProject.Entities.Contacts.MemberContacts", b =>
                {
                    b.HasOne("PhenixProject.Entities.Contacts.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("PhenixProject.Entities.Contacts.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId");

                    b.HasOne("PhenixProject.Entities.Contacts.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId");

                    b.HasOne("PhenixProject.Entities.Contacts.Phone", "SecondPhone")
                        .WithMany()
                        .HasForeignKey("SecondPhoneId");

                    b.HasOne("PhenixProject.Entities.Contacts.Skype", "Skype")
                        .WithMany()
                        .HasForeignKey("SkypeId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Department", b =>
                {
                    b.HasOne("PhenixProject.Entities.Office")
                        .WithMany("Departments")
                        .HasForeignKey("OfficeId");
                });

            modelBuilder.Entity("PhenixProject.Entities.EmployeeInfo", b =>
                {
                    b.HasOne("PhenixProject.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("PhenixProject.Entities.EmployeeHistory", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId");

                    b.HasOne("PhenixProject.Entities.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId");

                    b.HasOne("PhenixProject.Entities.Payroll", "Payroll")
                        .WithMany()
                        .HasForeignKey("PayrollId");

                    b.HasOne("PhenixProject.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Information.EducationInfo", b =>
                {
                    b.HasOne("PhenixProject.Entities.CandidateInfo")
                        .WithMany("Educations")
                        .HasForeignKey("CandidateInfoId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Information.WorkInfo", b =>
                {
                    b.HasOne("PhenixProject.Entities.CandidateInfo")
                        .WithMany("Works")
                        .HasForeignKey("CandidateInfoId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Leave", b =>
                {
                    b.HasOne("PhenixProject.Entities.EmployeeInfo")
                        .WithMany("Leaves")
                        .HasForeignKey("EmployeeInfoId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Link", b =>
                {
                    b.HasOne("PhenixProject.Entities.EmployeeInfo")
                        .WithMany("Links")
                        .HasForeignKey("EmployeeInfoId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Member", b =>
                {
                    b.HasOne("PhenixProject.Entities.CandidateInfo", "CandidateInfo")
                        .WithMany()
                        .HasForeignKey("CandidateInfoId");

                    b.HasOne("PhenixProject.Entities.EmployeeInfo", "EmployeeInfo")
                        .WithMany()
                        .HasForeignKey("EmployeeInfoId");

                    b.HasOne("PhenixProject.Entities.Office")
                        .WithMany("Members")
                        .HasForeignKey("OfficeId");

                    b.HasOne("PhenixProject.Entities.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonalInfoId");
                });

            modelBuilder.Entity("PhenixProject.Entities.PersonalInfo", b =>
                {
                    b.HasOne("PhenixProject.Entities.Contacts.MemberContacts", "Contacts")
                        .WithMany()
                        .HasForeignKey("ContactsId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Position", b =>
                {
                    b.HasOne("PhenixProject.Entities.Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("PhenixProject.Entities.Skill", b =>
                {
                    b.HasOne("PhenixProject.Entities.EmployeeInfo")
                        .WithMany("Skills")
                        .HasForeignKey("EmployeeInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
