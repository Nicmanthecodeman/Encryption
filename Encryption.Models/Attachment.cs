using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encryption.Models
{
    [Table("Attachments", Schema = "files")]
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string MimeType { get; set; }

        public DateTime Uploaded { get; set; }

        [ForeignKey("Uploader")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Uploader { get; set; }

        public byte[] Content { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}