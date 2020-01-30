using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenixProject.Models
{
    public class CalendarEventViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Color { get; set; }
    }
}
