using PhenixProject.Entities;
using PhenixProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Data;

namespace PhenixProject.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        private readonly AppIdentityDbContext _db;

        public MemberRepository(AppIdentityDbContext appContext)
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
            var member = _db.Members.FirstOrDefault(x => x.Id == id);
            if (member != null)
            {
                member.IsArchived = true;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var member = await _db.Members.FirstOrDefaultAsync(x => x.Id == id);
            if (member != null)
            {
                member.IsArchived = true;
            }
        }

        public IEnumerable<Member> Find(Func<Member, bool> predicate)
        {
            var members = _db.Members.Where(predicate).ToList();
            if (!members.Any()) return null;
            foreach (var entity in members)
            {
                _db.Entry(entity).Reference(x => x.PersonalInfo).Load();
                _db.Entry(entity).Reference(x => x.CandidateInfo).Load();
                _db.Entry(entity).Reference(x => x.EmployeeInfo).Load();
                _db.Entry(entity.PersonalInfo).Reference(x => x.Contacts).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Address).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Email).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Phone).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.SecondPhone).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Skype).Load();
                _db.Entry(entity.CandidateInfo).Collection(x => x.Educations).Load();
                _db.Entry(entity.CandidateInfo).Collection(x => x.Works).Load();
            }
            return members;
        }

        public async Task<IEnumerable<Member>> FindAsync(Func<Member, bool> predicate)
        {
            var members = _db.Members.Where(predicate).ToList();
            if (!members.Any()) return members;
            foreach (var entity in members)
            {
                await _db.Entry(entity).Reference(x => x.PersonalInfo).LoadAsync();
                await _db.Entry(entity).Reference(x => x.CandidateInfo).LoadAsync();
                await _db.Entry(entity).Reference(x => x.EmployeeInfo).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Reference(x => x.Office).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Reference(x => x.Department).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Reference(x => x.Position).LoadAsync();
                await _db.Entry(entity.PersonalInfo).Reference(x => x.Contacts).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Address).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Email).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Phone).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.SecondPhone).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Skype).LoadAsync();
                await _db.Entry(entity.CandidateInfo).Collection(x => x.Educations).LoadAsync();
                await _db.Entry(entity.CandidateInfo).Collection(x => x.Works).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Collection(x => x.Skills).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Collection(x => x.Links).LoadAsync();
            }
            return members;
        }

        public IEnumerable<Member> GetAll()
        {
            var members = _db.Members;
            if (!members.Any()) return null;
            foreach (var entity in members)
            {
                _db.Entry(entity).Reference(x => x.PersonalInfo).Load();
                _db.Entry(entity).Reference(x => x.CandidateInfo).Load();
                _db.Entry(entity).Reference(x => x.EmployeeInfo).Load();
                _db.Entry(entity.EmployeeInfo).Reference(x => x.Office).Load();
                _db.Entry(entity.EmployeeInfo).Reference(x => x.Department).Load();
                _db.Entry(entity.EmployeeInfo).Reference(x => x.Position).Load();
                _db.Entry(entity.PersonalInfo).Reference(x => x.Contacts).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Address).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Email).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Phone).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.SecondPhone).Load();
                _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Skype).Load();
                _db.Entry(entity.EmployeeInfo).Collection(x => x.Skills).Load();
                _db.Entry(entity.EmployeeInfo).Collection(x => x.Links).Load();
            }
            return members;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            var members = _db.Members;
            if (!members.Any()) return null;
            foreach (var entity in members)
            {
                await _db.Entry(entity).Reference(x => x.PersonalInfo).LoadAsync();
                await _db.Entry(entity).Reference(x => x.CandidateInfo).LoadAsync();
                await _db.Entry(entity).Reference(x => x.EmployeeInfo).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Reference(x => x.Office).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Reference(x => x.Department).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Reference(x => x.Position).LoadAsync();
                await _db.Entry(entity.PersonalInfo).Reference(x => x.Contacts).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Address).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Email).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Phone).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.SecondPhone).LoadAsync();
                await _db.Entry(entity.PersonalInfo.Contacts).Reference(x => x.Skype).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Collection(x => x.Skills).LoadAsync();
                await _db.Entry(entity.EmployeeInfo).Collection(x => x.Links).LoadAsync();
            }
            return members;
        }

        public Member GetById(Guid id)
        {
            var member = _db.Members.FirstOrDefault(x => x.Id == id);
            if (member == null) return null;
            _db.Entry(member).Reference(x => x.PersonalInfo).Load();
            _db.Entry(member).Reference(x => x.CandidateInfo).Load();
            _db.Entry(member).Reference(x => x.EmployeeInfo).Load();
            _db.Entry(member.PersonalInfo).Reference(x => x.Contacts).Load();
            _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Address).Load();
            _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Email).Load();
            _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Phone).Load();
            _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.SecondPhone).Load();
            _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Skype).Load();
            _db.Entry(member.CandidateInfo).Collection(x => x.Educations).Load();
            _db.Entry(member.CandidateInfo).Collection(x => x.Works).Load();
            _db.Entry(member.EmployeeInfo).Collection(x => x.Skills).Load();
            _db.Entry(member.EmployeeInfo).Collection(x => x.Links).Load();
            _db.Entry(member.EmployeeInfo).Collection(x => x.Leaves).Load();

            return member;
        }

        public async Task<Member> GetByIdAsync(Guid id)
        {
            var member = await _db.Members.FirstOrDefaultAsync(x => x.Id == id);
            if (member == null) return null;
            await _db.Entry(member).Reference(x => x.PersonalInfo).LoadAsync();
            await _db.Entry(member).Reference(x => x.CandidateInfo).LoadAsync();
            await _db.Entry(member).Reference(x => x.EmployeeInfo).LoadAsync();
            await _db.Entry(member.EmployeeInfo).Reference(x => x.Office).LoadAsync();
            await _db.Entry(member.EmployeeInfo).Reference(x => x.Department).LoadAsync();
            await _db.Entry(member.EmployeeInfo).Reference(x => x.Position).LoadAsync();
            await _db.Entry(member.EmployeeInfo).Reference(x => x.Payroll).LoadAsync();
            await _db.Entry(member.PersonalInfo).Reference(x => x.Contacts).LoadAsync();
            await _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Address).LoadAsync();
            await _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Email).LoadAsync();
            await _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Phone).LoadAsync();
            await _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.SecondPhone).LoadAsync();
            await _db.Entry(member.PersonalInfo.Contacts).Reference(x => x.Skype).LoadAsync();
            await _db.Entry(member.CandidateInfo).Collection(x => x.Educations).LoadAsync();
            await _db.Entry(member.CandidateInfo).Collection(x => x.Works).LoadAsync();
            await _db.Entry(member.EmployeeInfo).Collection(x => x.Skills).LoadAsync();
            await _db.Entry(member.EmployeeInfo).Collection(x => x.Links).LoadAsync();
            await _db.Entry(member.EmployeeInfo).Collection(x => x.Leaves).LoadAsync();
            return member;
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
