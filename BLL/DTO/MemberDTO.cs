using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class MemberDTO
    {
        public Guid Id { get; set; }
        public EmployeeDTO EmployeeInfo { get; set; }
        public CandidateDTO CandidateInfo { get; set; }
        public PersonalInfoDTO PersonalInfo { get; set; }
        public bool IsCandidate { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsArchived { get; set; }
    }
}
