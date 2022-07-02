using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Transfers
    {
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public int Amount { get; set; }
    }
}
