using RepositoryDB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBot.DataBase
{
    [Table("Auth_Codes")]
    internal class Auth_Code : Entity
    {
        [Column("Code")]
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [Column("IsActive")]
        [Required]
        public bool IsActive { get; set; }

        public Auth_Code(string code) 
        {
            Code = code;
            IsActive = false;
        }
        public Auth_Code(string code, bool isActive) : this (code)
        {
            IsActive = isActive;
        }

    }
}
