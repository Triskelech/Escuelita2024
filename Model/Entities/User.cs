using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("User")]
    public class User : Entity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        [ForeignKey("Account")]
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
