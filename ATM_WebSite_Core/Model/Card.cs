using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_WebSite_Core.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string NumberOfCard { get; set; }
        public string PinCode { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
