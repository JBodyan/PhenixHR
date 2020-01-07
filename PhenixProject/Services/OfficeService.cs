using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;


namespace PhenixProject.Services
{
    public class OfficeService : IOfficeService
    {

        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public OfficeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        public OfficeViewModel GetOfficeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OfficeViewModel> GetOfficeByIdAsync(Guid id)
        {
            if (id == null) throw new Exception("Ιd not specified");

            var offices = await _db.Offices.GetByIdAsync(id);
            if (offices == null) throw new Exception("Offices not found");

            var data = _mapper.Map<OfficeViewModel>(offices);
            return data;
        }

        public IEnumerable<OfficeViewModel> GetOffices()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OfficeViewModel>> GetOfficesAsync()
        {
            var offices = (await _db.Offices.GetAllAsync()).ToList();
            if (offices == null || (offices.Count < 1)) throw new Exception("No offices");

            var data = _mapper.Map<IEnumerable<OfficeViewModel>>(offices);
            return data;
        }

        public bool AddOffice(OfficeViewModel office)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddOfficeAsync(OfficeViewModel office)
        {
            try
            {
                var data = _mapper.Map<Office>(office);
                await _db.Offices.CreateAsync(data);
                _db.Save();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public void UpdateOffice(OfficeViewModel office)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOfficeAsync(OfficeViewModel office)
        {
            var data = _mapper.Map<Office>(office);
            await _db.Offices.UpdateAsync(data);
            _db.Save();
        }

        public void AddDepartmentByOfficeId(Guid id, DepartmentViewModel department)
        {
            var office = _db.Offices.GetById(id);
            if (office == null) throw new Exception("Office not found");
            if (department == null) throw new Exception("Department not specified");
            var data = _mapper.Map<Department>(department);
            office.Departments.Add(data);
            _db.Offices.Update(office);
            _db.Save();
        }

        public async Task AddDepartmentByOfficeIdAsync(Guid id, DepartmentViewModel department)
        {
            var office = await _db.Offices.GetByIdAsync(id);
            if (office == null) throw new Exception("Office not found");
            if (department == null) throw new Exception("Department not specified");
            var data = _mapper.Map<Department>(department);
            office.Departments.Add(data);
            await _db.Offices.UpdateAsync(office);
            _db.Save();
        }

        public void AddPositionByDepartmentId(Guid id, PositionViewModel position)
        {
            var department =  _db.Departments.GetById(id);
            if (department == null) throw new Exception("Department not found");
            if (position == null) throw new Exception("Position not specified");
            var data = _mapper.Map<Position>(position);
            department.Positions.Add(data);
            _db.Departments.Update(department);
            _db.Save();
        }

        public async Task AddPositionByDepartmentIdAsync(Guid id, PositionViewModel position)
        {
            var department = await _db.Departments.GetByIdAsync(id);
            if (department == null) throw new Exception("Department not found");
            if (position == null) throw new Exception("Position not specified");
            var data = _mapper.Map<Position>(position);
            department.Positions.Add(data);
            await _db.Departments.UpdateAsync(department);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
