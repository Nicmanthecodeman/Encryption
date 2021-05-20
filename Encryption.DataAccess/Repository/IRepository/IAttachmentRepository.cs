using Encryption.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encryption.DataAccess.Repository.IRepository
{
    public interface IAttachmentRepository : IRepository<Attachment>
    {
        Task<List<Attachment>> ProjectFilesToAttachmentList(
            IEnumerable<IFormFile> files,
            string password,
            ApplicationUser user);
    }
}
