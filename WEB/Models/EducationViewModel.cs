using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class EducationViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EducationalInstitution { get; set; }
        public string Education { get; set; }
        public string Faculty { get; set; }
    }
}
