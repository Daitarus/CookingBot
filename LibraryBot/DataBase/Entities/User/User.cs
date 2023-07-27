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

        [Column("State")]
        public int State { get; set; }



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
            IdTelegram = user.Id;
            IsBot = user.IsBot;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.Username;
            LanguageCode = user.LanguageCode;
            CanJoinGroups = user.CanJoinGroups;
            CanReadAllGroupMessages = user.CanReadAllGroupMessages;
            SupportsInlineQueries = user.SupportsInlineQueries;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is User user)
            {
                bool isEqual = true;
                isEqual = isEqual && IdTelegram == user.IdTelegram;
                isEqual = isEqual && IsBot == user.IsBot;
                isEqual = isEqual && FirstName == user.FirstName;
                isEqual = isEqual && LastName == user.LastName;
                isEqual = isEqual && UserName == user.UserName;
                isEqual = isEqual && LanguageCode == user.LanguageCode;
                isEqual = isEqual && CanJoinGroups == user.CanJoinGroups;
                isEqual = isEqual && CanReadAllGroupMessages == user.CanReadAllGroupMessages;
                isEqual = isEqual && SupportsInlineQueries == user.SupportsInlineQueries;

                return isEqual;
            }
            return false;
        }

        public void UpdateMainProperties(User user)
        {
            IdTelegram = user.IdTelegram;
            IsBot = user.IsBot;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            LanguageCode = user.LanguageCode;
            CanJoinGroups = user.CanJoinGroups;
            CanReadAllGroupMessages = user.CanReadAllGroupMessages;
            SupportsInlineQueries = user.SupportsInlineQueries;
        }
    }
}
