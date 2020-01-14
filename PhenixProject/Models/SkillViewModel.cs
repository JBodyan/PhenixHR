using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenixProject.Models
{
    public class SkillViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
