using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Context;

namespace Model.Entities
{
    public abstract class Entity
    {
        private EscuelitaContext _context;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [NotMapped]
        public bool IsNew
        {
            get
            {
                return Id == 0;
            }
        }

        public EscuelitaContext Context
        {
            get
            {
                return _context;
            }
        }

        public void SetDbContext(EscuelitaContext context)
        {
            _context = context;
        }

        public static EscuelitaContext GetContext()
        {
            return null; 
        }
    }
}
