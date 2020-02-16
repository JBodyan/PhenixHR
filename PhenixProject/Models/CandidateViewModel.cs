using Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using PhenixProject.Models.Information;

namespace PhenixProject.Models
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public Employment Employment { get; set; }
        public string City { get; set; }
        public string DesiredSalary { get; set; }
        public Currency Currency { get; set; }
        public PersonalInfoViewModel PersonalInfo { get; set; }
        public ICollection<WorkViewModel> Works { get; set; }
        public ICollection<EducationViewModel> Educations { get; set; }
        public string CareerObjective { get; set; }
        public string About { get; set; }

    }
}
