using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhenixProject.Entities;
using PhenixProject.Entities.Contacts;
using PhenixProject.Entities.Information;

namespace PhenixProject.Data
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
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
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
