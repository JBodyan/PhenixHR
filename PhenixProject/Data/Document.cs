using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenixProject.Data
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public DateTime UploadTime { get; set; }
        public string UserId { get; set; }
        public ICollection<DocumentTag> Tags { get; set; }
        public bool IsArchived { get; set; }

    }
}
