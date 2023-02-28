using RepositoryDB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBot.DataBase
{
    [Table("Books")]
    internal class Book : Entity
    {
        [Column("Name")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("Author")]
        [MaxLength(100)]
        public string Author { get; set; }

        [Column("Extension")]
        [MaxLength(10)]
        [Required]
        public string Extension { get; set; }

        [Column("Size")]
        [Required]
        public int Size { get; set; }

        [Column("Date_Added")]
        [Required]
        public DateTime Date_Added { get; set; }

        [Column("FileId")]
        [Required]
        public string FileId { get; set; }

        [Column("Relative_Path")]
        [MaxLength(500)]
        [Required]
        public string RelativePath { get; set; }

        [Column("Id_User")]
        [Required]
        public int UserId { get; set; }

        public Book(string name, string extension, int size , DateTime date_added, string fileId, string relativePath, int userId)
        {
            Name = name;
            Author = String.Empty;
            Extension = extension;
            Size = size;
            Date_Added = date_added;
            FileId = fileId;
            RelativePath = relativePath;
            UserId = userId;
        }

        public Book(string name, string author, string extension, int size, DateTime date_added, string fileId, string relativePath, int userId) : this(name, extension, size, date_added, fileId, relativePath, userId)
        {
            Author = author;
        }
    }
}
