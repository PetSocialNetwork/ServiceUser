using ServiceUser.Domain.Entities;

namespace ServiceUser.Domain.Interfaces
{
    public interface IUserProfileRepository : IRepositoryEF<UserProfile>
    {
        Task<UserProfile?> FindUserProfileAsync(Guid id, CancellationToken cancellationToken);
        Task<UserProfile?> FindUserProfileByAccountIdAsync(Guid accountId, CancellationToken cancellationToken);
    }
}
