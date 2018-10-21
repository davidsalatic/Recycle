using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Reciklaza.Data.Models
{
    public class ReciklaznoMesto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Unesi naziv!")]
        [MaxLength(60,ErrorMessage = "Predugačak naziv!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Unesi grad!")]
        [MaxLength(20)]
        public string Grad { get; set; }

        [Required(ErrorMessage = "Unesi adresu!")]
        [MaxLength(100, ErrorMessage = "Predugačka adresa!")]
        public string Adresa { get; set; }

        [MaxLength(25, ErrorMessage = "Predugačak broj!")]
        [Phone(ErrorMessage = "Broj telefona nije u dobrom formatu! (npr.+3816xxxxxxxx)")]
        public string Telefon { get; set; }

        [MaxLength(60, ErrorMessage = "Predugačka Email adresa!")]
        [EmailAddress(ErrorMessage = "To nije validna Email adresa!")]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "Predugačak url!")]
        [Url(ErrorMessage = @"To nije validan url! (primer: http://www.primer.com)")]
        public string Website { get; set; }
        
        [Required(ErrorMessage = "Izaberi tip materijala!")]
        [Display(Name = "Materijal")]
        public string NazivMaterijala { get; set; }

        [Required(ErrorMessage = "Unesi cenu!")]
        [Range(1,200,ErrorMessage = "Cena može biti najviše 200din/kg!")]
        [Display(Name ="Cena po kili")]
        public decimal CenaPoKg { get; set; }
        

    }    
}
