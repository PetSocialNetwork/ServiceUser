using Microsoft.EntityFrameworkCore;
using ServiceUser.Domain.Entities;
using ServiceUser.Domain.Interfaces;

namespace ServiceUser.DataEntityFramework.Repositories
{
    public class UserProfileRepository : EFRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<UserProfile?> FindUserProfileAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }

        public async Task<UserProfile?> FindUserProfileByAccountIdAsync(Guid accountId, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.AccountId == accountId, cancellationToken);
        }
    }
}
