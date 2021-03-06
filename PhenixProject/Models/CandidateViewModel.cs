﻿using Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
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
        public string PathCV { get; set; }
        public IFormFile File { get; set; }
        public bool IsArchived { get; set; }
        public override string ToString()
        {
            return string.Join(" ", Employment, City, DesiredSalary, Currency, CareerObjective, About);
        }
    }
}
