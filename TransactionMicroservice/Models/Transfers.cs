using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Transfers
    {
        [Required]
        public int SourceAccountId { get; set; }

        [Required]
        public int DestinationAccountId { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Amount can not be negative!")]
        public double Amount { get; set; }
    }
}
