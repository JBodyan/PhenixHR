using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface IOfficeService
    {
        OfficeViewModel GetOfficeById(Guid id);
        Task<OfficeViewModel> GetOfficeByIdAsync(Guid id);
        Task<IEnumerable<DepartmentViewModel>> GetDepartmentsByOfficeIdAsync(Guid officeId);
        Task<IEnumerable<PositionViewModel>> GetPositionsByDepartmentIdAsync(Guid departmentId);
        IEnumerable<OfficeViewModel> GetOffices();
        Task<IEnumerable<OfficeViewModel>> GetOfficesAsync();
        bool AddOffice(OfficeViewModel office);
        Task<bool> AddOfficeAsync(OfficeViewModel office);
        void UpdateOffice(OfficeViewModel office);
        Task UpdateOfficeAsync(OfficeViewModel office);
        void AddDepartmentByOfficeId(Guid id, DepartmentViewModel department);
        Task AddDepartmentByOfficeIdAsync(Guid id, DepartmentViewModel department);
        void AddPositionByDepartmentId(Guid id, PositionViewModel position);
        Task AddPositionByDepartmentIdAsync(Guid id, PositionViewModel position);
        void Dispose();
    }
}
