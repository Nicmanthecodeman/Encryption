using Encryption.DataAccess.Repository.IRepository;
using Encryption.Models;
using Encryption.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Encryption.DataAccess.Repository
{
    public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        private readonly ApplicationDbContext _db;        

        public AttachmentRepository(
            ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Attachment>> ProjectFilesToAttachmentList(
            IEnumerable<IFormFile> files,
            string password,
            ApplicationUser user)
        {
            List<Attachment> attachments = new();

            foreach (IFormFile file in files)
            {
                using MemoryStream memoryStream = new();
                await file.CopyToAsync(memoryStream);

                Attachment attachment = new()
                {
                    Content = memoryStream.ToArray(),
                    FileName = file.FileName,
                    Uploaded = DateTime.UtcNow,
                    ApplicationUserId = user.Id,
                    MimeType = file.ContentType,
                    Password = password
                };

                attachments.Add(attachment);
            }

            return attachments;
        }

        public void Update(Attachment attachment)
        {
            _db.Update(attachment);
        }

        public void UpdateRange(IEnumerable<Attachment> attachments)
        {
            _db.UpdateRange(attachments);
        }
    }
}
