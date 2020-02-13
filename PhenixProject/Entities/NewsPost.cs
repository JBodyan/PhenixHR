using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenixProject.Entities
{
    public class NewsPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public DateTime PostedTime { get; set; }
        public DateTime EditedTime { get; set; }

    }
}
