
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawFirmApp.Models
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }

        public required IFormFile FileName { get; set; }

        public required string ContentType { get; set; }

        [Column(TypeName = "image")]
        public required byte[] Content { get; set; }

    }
}
