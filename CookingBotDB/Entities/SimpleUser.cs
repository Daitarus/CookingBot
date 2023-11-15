using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookingBotDB.Entities
{
    [Table("SimpleUsers")]
    public class SimpleUser
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name"), MaxLength(10), Required]
        public string Name { get; set; }
    }
}
