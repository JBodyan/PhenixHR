using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenixProject.Models
{
    public class DocumentTagViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DocumentId { get; set; }

    }
}
