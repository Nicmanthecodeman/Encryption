using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encryption.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Attachments = new HashSet<Attachment>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
