using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Member> Members { get; }
        IRepository<Office> Offices { get; }
        IRepository<Department> Departments { get; }
        void Save();
    }
}
