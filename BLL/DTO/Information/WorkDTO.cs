using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Information
{
    public class WorkDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Position { get; set; }
        public string About { get; set; }
    }
}
