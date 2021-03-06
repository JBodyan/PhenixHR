﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhenixProject.Entities
{
    public class EmployeeInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Office Office { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public Payroll Payroll { get; set; }
        public ICollection<EmployeeHistory> Histories { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<Skill> Skills { get; set; }

    }
}
