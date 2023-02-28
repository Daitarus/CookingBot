using RepositoryDB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBot.DataBase
{
    [Table("Users")]
    public class User : Entity
    {
        [Column("Name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("UserId")]
        [Required]
        public long UserId { get; set; }

        [Column("State")]
        [Required]
        public int State { get; set; }

        [Column("Auth_Code_Id")]
        [Required]
        public int Auth_Code_Id { get; set; }

        public User(string name, long userId, int state = 0)
        {
            Name = name;
            UserId = userId;
            State = state;
        }
        public User(string name, long userId, int state, int auth_Code_Id) : this(name, userId, state)
        {
            Auth_Code_Id = auth_Code_Id;
        }
    }
}
