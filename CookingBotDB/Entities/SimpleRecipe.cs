using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBotDB.Entities
{
    [Table("SimpleRecipes")]
    public class SimpleRecipe
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name"), MaxLength(50), Required]
        public string Name { get; set; }

        [Column("user_id"), Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public SimpleUser User { get; set; }

        [Column("creation_date"), Required]
        public DateTime CreationDate { get; set; }

        [Column("last_update_date"), Required]
        public DateTime LastUpdateDate { get; set; }

        [Column("text"), Required]
        public string Text { get; set; }
    }
}
