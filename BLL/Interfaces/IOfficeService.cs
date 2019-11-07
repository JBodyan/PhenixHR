using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOfficeService
    {
        OfficeDTO GetOfficeById(Guid id);
        Task<OfficeDTO> GetOfficeByIdAsync(Guid id);
        IEnumerable<OfficeDTO> GetOffices();
        Task<IEnumerable<OfficeDTO>> GetOfficesAsync();
        bool AddOffice(OfficeDTO office);
        Task<bool> AddOfficeAsync(OfficeDTO office);
        void UpdateOffice(OfficeDTO office);
        Task UpdateOfficeAsync(OfficeDTO office);
        void AddDepartmentByOfficeId(Guid id, DepartmentDTO department);
        Task AddDepartmentByOfficeIdAsync(Guid id, DepartmentDTO department);
        void AddPositionByDepartmentId(Guid id, PositionDTO position);
        Task AddPositionByDepartmentIdAsync(Guid id, PositionDTO position);
        void Dispose();
    }
}
