using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        #region SyncMethods
        public bool AddMember(MemberViewModel member)
        {
            try
            {
                var data = _mapper.Map<Member>(member);
                _db.Members.Create(data);
                _db.Save();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public MemberViewModel GetMemberById(Guid id)
        {
            if (id == null) throw new Exception("Ιd not specified");

            var member = _db.Members.GetById(id);
            if (member == null)
                throw new Exception("Member not found");

            return _mapper.Map<MemberViewModel>(member);
        }

        public IEnumerable<MemberViewModel> GetMembers()
        {
            var members = _db.Members.GetAll().ToList();
            if (members == null || members.Count < 1) throw new Exception("No members");

            var data = _mapper.Map<IEnumerable<MemberViewModel>>(members);
            return data;
        }

        public void UpdateMember(MemberViewModel member)
        {
            throw new NotImplementedException();
        }

        public void AttachEmployeeInfo(MemberViewModel member)
        {
            throw new NotImplementedException();
        }

        public async Task AddHistoryAsync(Guid id, HistoryViewModel model)
        {
            var data = await _db.Members.GetByIdAsync(id);
            var history = _mapper.Map<EmployeeHistory>(model);
            history.Id = Guid.NewGuid();
            if (data.EmployeeInfo.Histories != null) data.EmployeeInfo.Histories.Add(history);
            else
            {
                data.EmployeeInfo.Histories = new List<EmployeeHistory>
                {
                    history
                };
            }
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }
        public async Task AddLinkAsync(Guid id, LinkViewModel model)
        {
            var data = await _db.Members.GetByIdAsync(id);
            var link = _mapper.Map<Link>(model);
            link.Id = Guid.NewGuid();
            if (data.EmployeeInfo.Links != null) data.EmployeeInfo.Links.Add(link);
            else
            {
                data.EmployeeInfo.Links = new List<Link>
                {
                    link
                };
            }
            data.EmployeeInfo.Histories.Add(new EmployeeHistory
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Event = $"Added link ({link.Url})"
            });
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        public async Task RemoveLinkAsync(Guid id, LinkViewModel model)
        {
            var data = await _db.Members.GetByIdAsync(id);
            var link = _mapper.Map<Link>(model);
            if (data.EmployeeInfo.Links != null)
            {
                data.EmployeeInfo.Histories.Add(new EmployeeHistory
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Event = $"Removed link ({link.Url})"
                });
                data.EmployeeInfo.Links.Remove(link);
                await _db.Members.UpdateAsync(data);
                _db.Save();
            }
        }

        public async Task UpdateLinkAsync(Guid id, LinkViewModel model)
        {
            var data = await _db.Members.GetByIdAsync(id);
            var link = data.EmployeeInfo.Links?.FirstOrDefault(x=>x.Id == model.Id);
            if (link != null)
            {
                data.EmployeeInfo.Histories.Add(new EmployeeHistory
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Event = $"Updated link ({link.Url} to {model.Url})"
                });
                link.Name = model.Name;
                link.Url = model.Url;
                
                await _db.Members.UpdateAsync(data);
                _db.Save();
            }
        }

        #endregion

        #region AsyncMethods
        public async Task<MemberViewModel> GetMemberByIdAsync(Guid id)
        {
            if (id == null) throw new Exception("Ιd not specified");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new Exception("Member not found");

            var data = _mapper.Map<MemberViewModel>(member);
            return data;
        }

        public async Task<IEnumerable<MemberViewModel>> GetMembersAsync()
        {
            IEnumerable<MemberViewModel> data;
            try
            {
                var members = (await _db.Members.GetAllAsync()).ToList();
                if (members == null || members.Count < 1) throw new Exception("No members");

                data = _mapper.Map<IEnumerable<MemberViewModel>>(members);
            }
            catch (Exception ex)
            {
                return null;
            }
            return data;

        }

        public async Task<bool> AddMemberAsync(MemberViewModel member)
        {
            try
            {
                var data = _mapper.Map<Member>(member);
                data.EmployeeInfo = new EmployeeInfo
                {
                    Id = Guid.NewGuid()
                };
                await _db.Members.CreateAsync(data);
                _db.Save();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public async Task UpdateMemberAsync(MemberViewModel member)
        {
            var data = _mapper.Map<Member>(member);
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        public async Task AttachEmployeeInfoAsync(MemberViewModel member)
        {
            var data = await _db.Members.GetByIdAsync(member.Id);
            if(data == null) throw new Exception("Member not found");
            var employeeProfile = _mapper.Map<EmployeeInfo>(member.EmployeeInfo);
            employeeProfile.Payroll.Id = Guid.NewGuid();
            data.EmployeeInfo.Links = new List<Link>();
            data.EmployeeInfo.Skills = new List<Skill>();
            data.EmployeeInfo.Histories = new List<EmployeeHistory>();
            data.PersonalInfo.Photo = @"/Photo/empty.png";
            data.EmployeeInfo = employeeProfile;
            data.IsCandidate = false;
            data.IsEmployee = true;
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        public async Task UpdateEmployeeInfoAsync(EmployeeViewModel employee)
        {
            var data = await _db.Members.GetByIdAsync(employee.Id);
            //Personal
            data.PersonalInfo.FirstName = employee.PersonalInfo.FirstName;
            data.PersonalInfo.MidName = employee.PersonalInfo.MidName;
            data.PersonalInfo.LastName = employee.PersonalInfo.LastName;
            data.PersonalInfo.BirthDate = employee.PersonalInfo.BirthDate;
            data.PersonalInfo.Gender = employee.PersonalInfo.Gender;
            //Contacts
            data.PersonalInfo.Contacts.Email.Value = employee.PersonalInfo.Contacts.Email.Value;
            data.PersonalInfo.Contacts.Phone.Value = employee.PersonalInfo.Contacts.Phone.Value;
            data.PersonalInfo.Contacts.SecondPhone.Value = employee.PersonalInfo.Contacts.SecondPhone.Value;
            data.PersonalInfo.Contacts.Skype.Value = employee.PersonalInfo.Contacts.Skype.Value;
            data.PersonalInfo.Contacts.Address.Value = employee.PersonalInfo.Contacts.Address.Value;
            //Employment
            data.EmployeeInfo.Payroll.Employment = employee.Payroll.Employment;
            data.EmployeeInfo.Payroll.Salary = employee.Payroll.Salary;
            data.EmployeeInfo.Payroll.Currency = employee.Payroll.Currency;
            //Department/Position
            var department = _mapper.Map<Department>(employee.Department);
            var position = _mapper.Map<Position>(employee.Position);
            data.EmployeeInfo.Department = department;
            data.EmployeeInfo.Position = position;

            data.EmployeeInfo.Histories.Add(new EmployeeHistory
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Event = "Updated employee information"
            });
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        public async Task UpdatePhotoAsync(Guid id, string path)
        {
            var data = await _db.Members.GetByIdAsync(id);
            data.PersonalInfo.Photo = path;
            data.EmployeeInfo.Histories.Add(new EmployeeHistory
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Event = "Changed photo"
            });
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        #endregion

        public async Task UpdateDepartmentAsync(EmployeeDepartmentViewModel model)
        {
            var data = await _db.Members.GetByIdAsync(model.EmployeeId);
            var office = await _db.Offices.GetByIdAsync(model.OfficeId);
            var department = await _db.Departments.GetByIdAsync(model.DepartmentId);
            var position = await _db.Positions.GetByIdAsync(model.PositionId);
            data.EmployeeInfo.Office = office;
            data.EmployeeInfo.Department = department;
            data.EmployeeInfo.Position = position;
            data.EmployeeInfo.Histories.Add(new EmployeeHistory
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Event = $"Department information (Transfered to {office.City}, {office.Address}, [{department.Name}, {position.Name}])"
            });
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        public async Task SendToArchive(Guid id)
        {
            var data = await _db.Members.GetByIdAsync(id);
            data.IsArchived = true;
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        
    }
}
