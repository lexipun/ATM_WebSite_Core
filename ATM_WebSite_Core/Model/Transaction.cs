using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_WebSite_Core.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public decimal CountMoney { get; set; }

        [ForeignKey("Card")]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

    }
}
