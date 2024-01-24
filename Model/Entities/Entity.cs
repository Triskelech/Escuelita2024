using Model.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
