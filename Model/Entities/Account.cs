using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("Account")]
    public class Account : Entity
    {
        public string? Code { get; set; }
        public int MoneyAmount { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Transfer> Transfers { get; set; }
    }
}
