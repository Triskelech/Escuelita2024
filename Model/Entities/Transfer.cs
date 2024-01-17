using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("Transfer")]
    public class Transfer : Entity
    {
        public string Code { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }

        [ForeignKey("OriginAccount")]
        public int OriginAccountId { get; set; }
        public virtual Account OriginAccount { get; set; }
    }
}
