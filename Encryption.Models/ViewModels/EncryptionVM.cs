using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Encryption.Models.ViewModels
{
    public class EncryptionVM
    {
        [Required]
        [Display(Name = "File(s)")]
        public List<IFormFile> FormFiles { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Download Encrypted File(s)")]
        public bool DownloadEncryptedFileAutomatically { get; set; } = true;
    }
}
