using RepositoryDB;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;

namespace LibraryBot.DataBase
{
    [Table("Documents")]
    internal class Document : Entity
    {
        [Column("Name")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("Author")]
        [MaxLength(100)]
        public string? Author { get; set; }

        [Column("Extension")]
        [MaxLength(10)]
        [Required]
        public string Extension { get; set; }

        [Column("Size")]
        [Required]
        public int Size { get; set; }

        [Column("DateAdded")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Column("RelativePath")]
        [MaxLength(500)]
        [Required]
        public string RelativePath { get; set; }

        [Column("UserId")]
        [Required]
        public int UserId { get; set; }

        public Document(string name, string extension, int size, DateTime dateAdded, string relativePath, int userId)
        {
            Name = name;
            Extension = extension;
            Size = size;
            DateAdded = dateAdded.ToUniversalTime();
            RelativePath = relativePath;
            UserId = userId;
        }
        public Document(string name, string author, string extension, int size, DateTime date_Added, string relativePath, int userId) : this(name, extension, size, date_Added, relativePath, userId)
        {
            Author = author;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Document document)
            {
                bool isEqual = true;
                isEqual = isEqual && (Name == document.Name);
                isEqual = isEqual && (Author == document.Author);
                isEqual = isEqual && (Extension == document.Extension);
                isEqual = isEqual && (Size == document.Size);
                isEqual = isEqual && (RelativePath == document.RelativePath);
                isEqual = isEqual && (UserId == document.UserId);

                return isEqual;
            }
            return false;
        }
    }
}
