using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhenixProject.Models
{
    public class UploadFileViewModel
    {
        public string UserId { get; set; }
        public IFormFile File { get; set; }

    }
}
