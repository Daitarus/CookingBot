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
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Column("LastName")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Column("UserName")]
        [MaxLength(50)]
        public string? UserName { get; set; }

        [Column("LanguageCode")]
        [MaxLength(10)]
        public string? LanguageCode { get; set; }

        [Column("CanJoinGroups")]
        public bool? CanJoinGroups { get; set; }

        [Column("CanReadAllGroupMessages")]
        public bool? CanReadAllGroupMessages { get; set; }

        [Column("SupportsInlineQueries")]
        public bool? SupportsInlineQueries { get; set; }

        public User(long idTelegram, bool isBot, string firstName, string? lastName, string? userName, string? languageCode, bool? canJoinGroups, bool? canReadAllGroupMessages, bool? supportsInlineQueries)
        {
            IdTelegram = idTelegram;
            IsBot = isBot;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            LanguageCode = languageCode;
            CanJoinGroups = canJoinGroups;
            CanReadAllGroupMessages = canReadAllGroupMessages;
            SupportsInlineQueries = supportsInlineQueries;
        }

        public User(Telegram.Bot.Types.User user)
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
        }

        public bool EqualForMainArgs(User? user)
        {
            if(user != null)
            {
                bool isEqual = true;

                isEqual = isEqual && (this.IdTelegram == user.IdTelegram);
                isEqual = isEqual && (this.IsBot == user.IsBot);
                isEqual = isEqual && (this.FirstName == user.FirstName);
                isEqual = isEqual && (this.LastName == user.LastName);
                isEqual = isEqual && (this.UserName == user.UserName);
                isEqual = isEqual && (this.LanguageCode == user.LanguageCode);
                isEqual = isEqual && (this.CanJoinGroups == user.CanJoinGroups);
                isEqual = isEqual && (this.CanReadAllGroupMessages == user.CanReadAllGroupMessages);
                isEqual = isEqual && (this.SupportsInlineQueries == user.SupportsInlineQueries);

                return isEqual;
            }

            return false;
        }

        public void UpdateMainArgs(User newUser)
        {
            this.IdTelegram = newUser.IdTelegram;
            this.IsBot = newUser.IsBot;
            this.FirstName = newUser.FirstName;
            this.LastName = newUser.LastName;
            this.UserName = newUser.UserName;
            this.LanguageCode = newUser.LanguageCode;
            this.CanJoinGroups = newUser.CanJoinGroups;
            this.CanReadAllGroupMessages = newUser.CanReadAllGroupMessages;
            this.SupportsInlineQueries = newUser.SupportsInlineQueries;
        }
    }
}
