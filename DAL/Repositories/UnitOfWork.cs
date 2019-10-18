using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Data.AppContext _db;
        private MemberRepository memberRepository;

        public UnitOfWork(string connectionString)
        {
            _db = new Data.AppContext(connectionString);
        }

        public IRepository<Member> Members
        {
            get
            {
                if (memberRepository == null)
                    memberRepository = new MemberRepository(_db);
                return memberRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
