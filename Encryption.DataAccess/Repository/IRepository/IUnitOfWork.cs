using System;
using System.Threading.Tasks;

namespace Encryption.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }

        IAttachmentRepository Attachment { get; }

        Task SaveAsync();
    }
}
