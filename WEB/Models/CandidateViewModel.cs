using Resources.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public Employment Employment { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string DesiredSalary { get; set; }
        public ICollection<WorkViewModel> Works { get; set; }
        public ICollection<EducationViewModel> Educations { get; set; }
        [Required]
        public string CareerObjective { get; set; }
        public string About { get; set; }
        [Required]
        public PersonalnfoViewModel PersonalInfo { get; set; }
    }
}
