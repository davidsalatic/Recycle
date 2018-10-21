using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciklaza.Data.Models
{
    public class Materijal
    {
        public int Id { get; set; }
        

        [Required(ErrorMessage = "Unesi naziv!")]
        [MaxLength(50, ErrorMessage = "Predugačak naziv!")]
        public string Naziv { get; set; }
    }
}
