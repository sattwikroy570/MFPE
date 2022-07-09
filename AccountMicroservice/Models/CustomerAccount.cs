using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice
{
    public class CustomerAccount
    {
        [Key]
        public string CustomerId { get; set; }
        public int CurrentAccountId { get; set; }
        public int SavingsAccountId { get; set; }
    }
}
