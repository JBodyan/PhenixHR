using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class HistoryDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Event { get; set; }
    }
}
