using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class WorkViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Position { get; set; }
        public string About { get; set; }
    }
}
