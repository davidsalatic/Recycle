using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reciklaza.Data.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Korisnicko ime")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Lozinka")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}