using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models
{
    public class HistoryViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Event { get; set; }
    }
}
