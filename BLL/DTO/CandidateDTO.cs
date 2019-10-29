using BLL.DTO.Information;
using Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CandidateDTO
    {
        public Guid Id { get; set; }
        public Employment Employment { get; set; }
        public string City { get; set; }
        public string DesiredSalary { get; set; }
        public ICollection<WorkDTO> Works { get; set; }
        public ICollection<EducationDTO> Educations { get; set; }
        public string CareerObjective { get; set; }
        public string About { get; set; }

    }
}
