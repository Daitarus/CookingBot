﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBotDB.Entities
{
    [Table("Recipes")]
    public class Recipe
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("number"), Required]
        public int Number { get; set; }

        [Column("name"), MaxLength(50), Required]
        public string Name { get; set; }

        [Column("user_id"), Required]
        public int UserId{ get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Column("creation_date"), Required]
        public DateTime CreationDate { get; set; }

        [Column("last_update_date"), Required]
        public DateTime LastUpdateDate { get; set; }

        [Column("text"), Required]
        public string Text { get; set; }
    }
}
