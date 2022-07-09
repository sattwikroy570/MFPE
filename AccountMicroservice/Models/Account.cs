using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Range(1,double.MaxValue)]
        public double Balance { get; set; }
    }
}
