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

        [Column("Auth_Codes_Id")]
        [Required]
        public int Auth_Codes_Id { get; set; }

        public User(long idTelegram, bool isBot, string firstName, string? lastName, string? userName, string? languageCode, bool? canJoinGroups, bool? canReadAllGroupMessages, bool? supportsInlineQueries, int state, int auth_Codes_Id)
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
            State = state;
            Auth_Codes_Id = auth_Codes_Id;
        }

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
        public User(Telegram.Bot.Types.User user, int state , int auth_Codes_Id) : this(user, state)
        {
            this.Auth_Codes_Id = auth_Codes_Id;
        }

        public bool EqualsForMainArgs(User? user)
        {
            if(user != null)
            {
                bool result = true;

                result = result && (this.IdTelegram == user.IdTelegram);
                result = result && (this.IsBot == user.IsBot);
                result = result && (this.FirstName == user.FirstName);
                result = result && (this.LastName == user.LastName);
                result = result && (this.UserName == user.UserName);
                result = result && (this.LanguageCode == user.LanguageCode);
                result = result && (this.CanJoinGroups == user.CanJoinGroups);
                result = result && (this.CanReadAllGroupMessages == user.CanReadAllGroupMessages);
                result = result && (this.SupportsInlineQueries == user.SupportsInlineQueries);

                return result;
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

        public enum StateOptions : int
        {
            Start = 0,
            StartAuthorized = 1
        }
    }
}
