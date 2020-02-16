using PhenixProject.Entities.Information;
using Resources.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhenixProject.Entities
{
    public class CandidateInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Employment Employment { get; set; }
        public string City { get; set; }
        public string DesiredSalary { get; set; }
        public Currency Currency { get; set; }
        public ICollection<WorkInfo> Works { get; set; }
        public ICollection<EducationInfo> Educations { get; set; }
        public string CareerObjective { get; set; }
        public string About { get; set; }
    }
}
