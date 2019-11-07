using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.ExceptionStructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
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

        public OfficeDTO GetOfficeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OfficeDTO> GetOfficeByIdAsync(Guid id)
        {
            if (id == null) throw new CustomValidationException("Ιd not specified", "");

            var offices = await _db.Offices.GetByIdAsync(id);
            if (offices == null) throw new CustomValidationException("Offices not found", "");

            var data = _mapper.Map<OfficeDTO>(offices);
            return data;
        }

        public IEnumerable<OfficeDTO> GetOffices()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OfficeDTO>> GetOfficesAsync()
        {
            var offices = (await _db.Offices.GetAllAsync()).ToList();
            if (offices == null || offices.Count < 1) throw new CustomValidationException("No offices", "");

            var data = _mapper.Map<IEnumerable<OfficeDTO>>(offices);
            return data;
        }

        public bool AddOffice(OfficeDTO office)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddOfficeAsync(OfficeDTO office)
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

        public void UpdateOffice(OfficeDTO office)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOfficeAsync(OfficeDTO office)
        {
            var data = _mapper.Map<Office>(office);
            await _db.Offices.UpdateAsync(data);
            _db.Save();
        }

        public void AddDepartmentByOfficeId(Guid id, DepartmentDTO department)
        {
            var office = _db.Offices.GetById(id);
            if (office == null) throw new CustomValidationException("Office not found","");
            if (department == null) throw new CustomValidationException("Department not specified","");
            var data = _mapper.Map<Department>(department);
            office.Departments.Add(data);
            _db.Offices.Update(office);
            _db.Save();
        }

        public async Task AddDepartmentByOfficeIdAsync(Guid id, DepartmentDTO department)
        {
            var office = await _db.Offices.GetByIdAsync(id);
            if (office == null) throw new CustomValidationException("Office not found", "");
            if (department == null) throw new CustomValidationException("Department not specified", "");
            var data = _mapper.Map<Department>(department);
            office.Departments.Add(data);
            await _db.Offices.UpdateAsync(office);
            _db.Save();
        }

        public void AddPositionByDepartmentId(Guid id, PositionDTO position)
        {
            var department =  _db.Departments.GetById(id);
            if (department == null) throw new CustomValidationException("Office not found", "");
            if (position == null) throw new CustomValidationException("Department not specified", "");
            var data = _mapper.Map<Position>(position);
            department.Positions.Add(data);
            _db.Departments.Update(department);
            _db.Save();
        }

        public async Task AddPositionByDepartmentIdAsync(Guid id, PositionDTO position)
        {
            var department = await _db.Departments.GetByIdAsync(id);
            if (department == null) throw new CustomValidationException("Office not found", "");
            if (position == null) throw new CustomValidationException("Department not specified", "");
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
