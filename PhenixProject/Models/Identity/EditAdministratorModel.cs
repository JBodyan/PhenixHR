using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhenixProject.Models.Identity
{
    public class EditAdministratorModel
    {
        public string Id { get; set; }

        [Display(Name = "UserName")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public string Photo { get; set; }

    }

}
