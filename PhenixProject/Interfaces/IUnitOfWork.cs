﻿using PhenixProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhenixProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Member> Members { get; }
        IRepository<Office> Offices { get; }
        IRepository<Department> Departments { get; }
        IRepository<Leave> Leaves { get; }
        IRepository<EmployeeHistory> Histories { get; }
        IRepository<Payroll> Payrolls { get; }
        IRepository<Link> Links { get; }
        IRepository<Skill> Skills { get; }
        Task SaveAsync();
        void Save();
    }
}
