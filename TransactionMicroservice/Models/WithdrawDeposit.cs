using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class WithdrawDeposit
    {
        public int AccountId { get; set; }
        public int Amount { get; set; }
    }
}
