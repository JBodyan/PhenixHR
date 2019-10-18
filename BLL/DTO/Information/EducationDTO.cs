using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Information
{
    public class EducationDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EducationalInstitution { get; set; }
        public string Education { get; set; }
        public string Faculty { get; set; }
    }
}
