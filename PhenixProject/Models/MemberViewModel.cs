using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models
{
    public class MemberViewModel
    {
        public Guid Id { get; set; }
        public EmployeeViewModel EmployeeInfo { get; set; }
        public CandidateViewModel CandidateInfo { get; set; }
        public PersonalInfoViewModel PersonalInfo { get; set; }
        public bool IsCandidate { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsArchived { get; set; }
    }
}
