using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhenixProject.Models
{
    public class NewsPostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public DateTime PostedTime { get; set; }
        public DateTime EditedTime { get; set; }
        public IFormFile File { get; set; }
    }
}
