using DAL.Entities;
using DAL.Entities.Contacts;
using DAL.Entities.Information;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Resources.Enums;
using System.Text;

namespace DAL.Data
{
    public class AppContext : DbContext
    {
        private readonly string _connection;
        public AppContext(string connectionString)
        {
            _connection = connectionString;
            Database.EnsureCreated();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<CandidateInfo> CandidateInfos { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<MemberContacts> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Skype> Skypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationInfo> EducationInfos { get; set; }
        public DbSet<WorkInfo> WorkInfos { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var _id = Guid.NewGuid();
            //modelBuilder.Entity<Member>().HasData(new Member
            //{
            //    Id = _id,
            //    IsCandidate = true,
            //    PersonalInfo = new PersonalInfo
            //    {
            //        Id = _id,
            //        Contacts = new MemberContacts
            //        {
            //            Phones = new List<Phone> { new Phone { Value = "+38(067)210-36-89" } },
            //            Emails = new List<Email> { new Email { Value = "jstix.bogdan.kandela@gmail.com" } }

            //        },
            //        BirthDate = new DateTime(1997, 7, 24),
            //        FirstName = "Bogdan",
            //        MidName = "Igorevich",
            //        LastName = "Kandela",
            //        Gender = Gender.Male,

            //    },
            //    CandidateInfo = new CandidateInfo
            //    {
            //        Id = _id,
            //        About = "Student",
            //        DesiredSalary = "500$",
            //        City = "Dnipro",
            //        CareerObjective = "Junior .NET Developer",
            //        Employment = Employment.FullTime,
            //        Works = new List<WorkInfo>
            //        {
            //            new WorkInfo{Position = "Junior .NET Developer"}
            //        }
            //    }
            //});
            base.OnModelCreating(modelBuilder);
        }
    }
}
