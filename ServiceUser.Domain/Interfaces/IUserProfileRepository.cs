using ServiceUser.Domain.Entities;
using ServiceUser.Domain.Shared;

namespace ServiceUser.Domain.Interfaces
{
    public interface IUserProfileRepository : IRepositoryEF<UserProfile>
    {
        Task<UserProfile?> FindUserProfileAsync(Guid id, CancellationToken cancellationToken);
        Task<UserProfile?> FindUserProfileByAccountIdAsync(Guid accountId, CancellationToken cancellationToken);
        Task<List<UserProfile>> GetUserProfilesAsync(List<Guid> userIds, CancellationToken cancellationToken);
        Task<List<UserProfile>> FindUserProfileByNameAsync(string firstName, string lastName, PaginationOptions options, CancellationToken cancellationToken);
    }
}
