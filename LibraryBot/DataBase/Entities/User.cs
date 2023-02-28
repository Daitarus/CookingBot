using RepositoryDB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBot.DataBase
{
    [Table("Users")]
    public class User : Entity
    {
        [Column("IdTelegram")]
        [Required]
        public long IdTelegram { get; set; }

        [Column("IsBot")]
        [Required]
        public bool IsBot { get; set; }

        [Column("FirstName")]
        [Required]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string? LastName { get; set; }

        [Column("UserName")]
        public string? UserName { get; set; }

        [Column("LanguageCode")]
        public string? LanguageCode { get; set; }

        [Column("CanJoinGroups")]
        public bool? CanJoinGroups { get; set; }

        [Column("CanReadAllGroupMessages")]
        public bool? CanReadAllGroupMessages { get; set; }

        [Column("SupportsInlineQueries")]
        public bool? SupportsInlineQueries { get; set; }

        [Column("State")]
        [Required]
        public int State { get; set; }

        [Column("Auth_Code_Id")]
        [Required]
        public int Auth_Code_Id { get; set; }

        public User(Telegram.Bot.Types.User user, int state = 0)
        {
            this.IdTelegram = user.Id;
            this.IsBot = user.IsBot;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserName = user.Username;
            this.LanguageCode = user.LanguageCode;
            this.CanJoinGroups = user.CanJoinGroups;
            this.CanReadAllGroupMessages = user.CanReadAllGroupMessages;
            this.SupportsInlineQueries = user.SupportsInlineQueries;
            this.State = state;
        }
        public User(Telegram.Bot.Types.User user, int state , int auth_code_id) : this(user, state)
        {
            this.Auth_Code_Id = auth_code_id;
        }
    }
}
