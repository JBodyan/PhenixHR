using BLL.DTO;
using BLL.DTO.Information;
using Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public Employment Employment { get; set; }
        public string City { get; set; }
        public string DesiredSalary { get; set; }
        public ICollection<WorkDTO> Works { get; set; }
        public ICollection<EducationDTO> Educations { get; set; }
        public string CareerObjective { get; set; }
        public string About { get; set; }
        public PersonalInfoDTO PersonalInfo { get; set; }
    }
}
