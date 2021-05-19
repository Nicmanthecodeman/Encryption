using Encryption.DataAccess.Repository.IRepository;
using Encryption.Models;
using System.Collections.Generic;

namespace Encryption.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser user)
        {
            _db.Update<ApplicationUser>(user);
        }

        public void UpdateRange(IEnumerable<ApplicationUser> users)
        {
            _db.UpdateRange(users);
        }
    }
}
