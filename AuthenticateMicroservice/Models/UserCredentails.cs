using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticateMicroservice.Models
{
    public class UserCredentails
    {
        [Required]
        [Key]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^Employee$|^Customer$", ErrorMessage = "Invalid Role")]
        public string Roles { get; set; }
    }
}
