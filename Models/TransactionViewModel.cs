using System;
using System.Collections.Generic;
using BankWebApplication.Data;

namespace BankWebApplication.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }


        public DateTime Data { get; set; }

        public string TakerCompany { get; set; }

        public decimal Cash { get; set; }

        public string ReasonForPaymont { get; set; }


    }
}
