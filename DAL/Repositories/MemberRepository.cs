using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        private Data.AppContext db;

        public MemberRepository(Data.AppContext appContext)
        {
            db = appContext;
        }

        public void Create(Member item)
        {
            db.Members.Add(item);
        }

        public async Task CreateAsync(Member item)
        {
            await db.AddAsync(item);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> Find(Func<Member, bool> predicate)
        {
            return db.Members.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Member>> FindAsync(Func<Member, bool> predicate)
        {
            return db.Members.Where(predicate).ToList();
        }

        public IEnumerable<Member> GetAll()
        {
            return db.Members;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return db.Members;
        }

        public Member GetById(Guid id)
        {
            return db.Members.Find(id);
        }

        public async Task<Member> GetByIdAsync(Guid id)
        {
            return await db.Members.FindAsync(id);
        }

        public void Update(Member item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Member item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
