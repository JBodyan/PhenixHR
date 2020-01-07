using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models.Information
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
