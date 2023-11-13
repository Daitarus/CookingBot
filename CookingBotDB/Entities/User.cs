using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CookingBotDB.Entities.Base;

namespace CookingBotDB.Entities
{
    [Table("Users")]
    public class User : Entity
    {
        [Column("telegram_id"), Required]
        public long TelegramId { get; set; }

        [Column("is_bot"), Required]
        public bool IsBot { get; set; }

        [Column("first_name"), MaxLength(50), Required]
        public string FirstName { get; set; }

        [Column("last_name"), MaxLength(50)]
        public string? LastName { get; set; }

        [Column("user_name"), MaxLength(50)]
        public string? UserName { get; set; }

        [Column("language_code"), MaxLength(10)]
        public string? LanguageCode { get; set; }

        [Column("can_join_groups")]
        public bool? CanJoinGroups { get; set; }

        [Column("can_read_all_group_messages")]
        public bool? CanReadAllGroupMessages { get; set; }

        [Column("supports_inline_queries")]
        public bool? SupportsInlineQueries { get; set; }

        [Column("state", TypeName = "int")]
        public UserState State { get; set; }


        public User(Telegram.Bot.Types.User user)
        {
            TelegramId = user.Id;
            IsBot = user.IsBot;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.Username;
            LanguageCode = user.LanguageCode;
            CanJoinGroups = user.CanJoinGroups;
            CanReadAllGroupMessages = user.CanReadAllGroupMessages;
            SupportsInlineQueries = user.SupportsInlineQueries;
        }
    }

    public enum UserState
    {
        Initial = 0,
        AddDocument = 1,
        DeleteDocument = 2,
        AddFolder = 3,
        DeleteFolder = 4,
        GetDocument = 5
    }
}
