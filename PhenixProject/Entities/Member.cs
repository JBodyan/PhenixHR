using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhenixProject.Entities
{
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public EmployeeInfo EmployeeInfo { get; set; }
        public CandidateInfo CandidateInfo { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public bool IsCandidate { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsArchived { get; set; }

    }
}
