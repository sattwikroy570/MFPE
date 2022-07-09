using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Models
{
    public class AccountStatement
    {

        [Key]
        public int AccountId { get; set; }
        public List<Statement> Statements { get; set; }
    }
}
