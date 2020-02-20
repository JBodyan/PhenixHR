using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenixProject.Models
{
    public class DocumentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public DateTime UploadTime { get; set; }
        public string UserId { get; set; }
        public IEnumerable<DocumentTagViewModel> Tags { get; set; }
        public bool IsArchived { get; set; }
        public string TagsToString => string.Join(", ", Tags);
        public override string ToString()
        {
            return string.Join(" ", TagsToString, Name, Description, UploadTime);
        }
    }
}
