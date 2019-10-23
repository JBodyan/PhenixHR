using Resources.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models.Contacts;

namespace WEB.Models
{
    public class PersonalnfoViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(50, ErrorMessage = "{0} length can't be more than {1}.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(50, ErrorMessage = "{0} length can't be more than {1}.")]
        public string MidName { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(50, ErrorMessage = "{0} length can't be more than {1}.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Required field")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Required field")]
        public ContactsViewModel Contacts { get; set; }
        public string Photo { get; set; }
    }
}
