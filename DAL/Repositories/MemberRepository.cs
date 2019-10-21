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
        private readonly Data.AppContext _db;

        public MemberRepository(Data.AppContext appContext)
        {
            _db = appContext;
        }

        public void Create(Member item)
        {
            _db.Members.Add(item);
        }

        public async Task CreateAsync(Member item)
        {
            await _db.AddAsync(item);
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
            var members = _db.Members.Where(predicate).ToList();
            foreach (var entity in members)
            {
                _db.Entry(entity).Reference(x => x.PersonalInfo).Load();
                _db.Entry(entity).Reference(x => x.CandidateInfo).Load();
                _db.Entry(entity).Reference(x => x.EmployeeInfo).Load();
                _db.Entry(entity.PersonalInfo).Reference(x => x.Contacts).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Collection(x => x.Address).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Collection(x => x.Emails).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Collection(x => x.Phones).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Collection(x => x.Skypes).Load();
                _db.Entry(entity.CandidateInfo).Collection(x => x.Educations).Load();
                _db.Entry(entity.CandidateInfo).Collection(x => x.Works).Load();
            }
            return members;
        }

        public async Task<IEnumerable<Member>> FindAsync(Func<Member, bool> predicate)
        {
            return _db.Members.Where(predicate).ToList();
        }

        public IEnumerable<Member> GetAll()
        {
            var members = _db.Members;
            _db.Members.Where(x=> members.Contains(x)).Load();
            return members;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return _db.Members;
        }

        public Member GetById(Guid id)
        {
            return _db.Members.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Member> GetByIdAsync(Guid id)
        {
            return await _db.Members.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Member item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Member item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
