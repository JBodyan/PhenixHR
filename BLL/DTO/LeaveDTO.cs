using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class LeaveDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalDays { get; set; }
    }
}
