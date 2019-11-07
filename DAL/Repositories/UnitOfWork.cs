﻿using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Data.AppContext _db;
        private MemberRepository _memberRepository;
        private OfficeRepository _officeRepository;
        private DepartmentRepository _departmentRepository;
        public UnitOfWork(string connectionString)
        {
            _db = new Data.AppContext(connectionString);
        }

        public IRepository<Member> Members
        {
            get
            {
                if (_memberRepository == null)
                    _memberRepository = new MemberRepository(_db);
                return _memberRepository;
            }
        }

        public IRepository<Office> Offices
        {
            get
            {
                if (_officeRepository == null)
                    _officeRepository = new OfficeRepository(_db);
                return _officeRepository;
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_db);
                return _departmentRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
