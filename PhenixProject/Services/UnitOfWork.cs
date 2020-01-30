using PhenixProject.Entities;
using PhenixProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Data;
using PhenixProject.Repositories;

namespace PhenixProject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _db;
        private MemberRepository _memberRepository;
        private OfficeRepository _officeRepository;
        private DepartmentRepository _departmentRepository;
        private LeaveRepository _leaveRepository;
        private HistoryRepository _historyRepository;
        private PayrollRepository _payrollRepository;
        private LinkRepository _linkRepository;
        private SkillRepository _skillRepository;
        private DocumentRepository _documentRepository;
        private TagRepository _tagRepository;
        private CalendarRepository _calendarRepository;
        public UnitOfWork(AppIdentityDbContext context)
        {
            _db = context;
        }

        public IRepository<CalendarEvent> CalendarEvent
        {
            get
            {
                if (_calendarRepository == null)
                    _calendarRepository = new CalendarRepository(_db);
                return _calendarRepository;
            }
        }

        public IRepository<DocumentTag> Tags
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(_db);
                return _tagRepository;
            }
        }

        public IRepository<Payroll> Payrolls
        {
            get
            {
                if (_payrollRepository == null)
                    _payrollRepository = new PayrollRepository(_db);
                return _payrollRepository;
            }
        }
        
        public IRepository<Document> Documents
        {
            get
            {
                if (_documentRepository == null)
                    _documentRepository = new DocumentRepository(_db);
                return _documentRepository;
            }
        }
        public IRepository<Link> Links
        {
            get
            {
                if (_linkRepository == null)
                    _linkRepository = new LinkRepository(_db);
                return _linkRepository;
            }
        }
        public IRepository<Skill> Skills
        {
            get
            {
                if (_skillRepository == null)
                    _skillRepository = new SkillRepository(_db);
                return _skillRepository;
            }
        }
        public IRepository<EmployeeHistory> Histories
        {
            get
            {
                if (_historyRepository == null)
                    _historyRepository = new HistoryRepository(_db);
                return _historyRepository;
            }
        }
        public IRepository<Leave> Leaves
        {
            get
            {
                if (_leaveRepository == null)
                    _leaveRepository = new LeaveRepository(_db);
                return _leaveRepository;
            }
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

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
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
