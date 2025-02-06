using ServiceUser.Domain.Entities;
using ServiceUser.Domain.Exceptions;
using ServiceUser.Domain.Interfaces;

namespace ServiceUser.Domain.Services
{
    public class UserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository
                ?? throw new ArgumentException(nameof(userProfileRepository));
        }

        public async Task<UserProfile> GetUserProfileByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await _userProfileRepository.GetById(id, cancellationToken);
            }
            catch (InvalidOperationException)
            {
                throw new UserProfileNotFoundException("Пользователя с таким профилем не существует.");
            }
        }

        public async Task<UserProfile> GetUserProfileByAccountIdAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var existedProfile = await _userProfileRepository.FindUserProfileByAccountIdAsync(accountId, cancellationToken);
            if (existedProfile is null)
            {
                throw new UserProfileNotFoundException("Пользователя с таким профилем не существует.");
            }

            return existedProfile;
        }

        public async Task<UserProfile> AddUserProfileAsync(Guid accountId, CancellationToken cancellationToken)
        {
            if (!await IsAddUserProfileAvailable(accountId, cancellationToken))
            {
                throw new UserProfileWithAccountAlreadyExistsException("У данного аккаунта профиль уже существует.");
            };

            UserProfile userProfile = new UserProfile(Guid.NewGuid(), accountId) { IsProfileCompleted = false };

            await _userProfileRepository.Add(userProfile, cancellationToken);
            return userProfile;
        }

        public async Task UpdateUserProfileAsync(UserProfile userProfile, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(userProfile);
            var existedProfile = await _userProfileRepository.FindUserProfileAsync(userProfile.Id, cancellationToken);
            if (existedProfile is null)
            {
                throw new UserProfileNotFoundException("Пользователя с таким профилем не существует.");
            }

            existedProfile.Profession = userProfile.Profession;
            existedProfile.DateOfBirth = userProfile.DateOfBirth;
            existedProfile.FirstName = userProfile.FirstName;
            existedProfile.LastName = userProfile.LastName;
            existedProfile.WalksDogs = userProfile.WalksDogs;
            //Ставим true, так как Имя и Фамилия, передаваемы через request не могут быть переданными пустыми
            existedProfile.IsProfileCompleted = true;

            await _userProfileRepository.Update(existedProfile, cancellationToken);
        }

        public async Task DeleteUserProfileAsync(Guid id, CancellationToken cancellationToken)
        {
            var existedProfile = await _userProfileRepository.FindUserProfileAsync(id, cancellationToken);
            if (existedProfile is null)
            {
                throw new UserProfileNotFoundException("Пользователя с таким профилем не существует.");
            }

            await _userProfileRepository.Delete(existedProfile, cancellationToken);
        }

        public async Task DeleteUserProfileByAccountIdAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var existedProfile = await _userProfileRepository.FindUserProfileByAccountIdAsync(accountId, cancellationToken);
            if (existedProfile is null)
            {
                throw new UserProfileNotFoundException("Пользователя с таким профилем не существует.");
            }

            await _userProfileRepository.Delete(existedProfile, cancellationToken);
        }

        private async Task<bool> IsAddUserProfileAvailable(Guid accountId, CancellationToken cancellationToken)
        {
            try
            {
                var existedUserProfile = await _userProfileRepository.FindUserProfileByAccountIdAsync(accountId, cancellationToken);
                if (existedUserProfile != null)
                {
                    return false;
                }
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }

        public async Task<List<UserProfile>> FindUserProfileByNameAsync(string firstName, string lastName, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nameof(firstName));
            ArgumentException.ThrowIfNullOrWhiteSpace(nameof(lastName));

            return await _userProfileRepository.FindUserProfileByNameAsync(firstName, lastName, cancellationToken);
        }

        public async Task<List<UserProfile>> GetUserProfilesAsync(List<Guid> userIds, CancellationToken cancellationToken)
        {
            if (userIds == null || userIds.Count == 0)
            {
                throw new UserProfileNotFoundException("Коллекция пуста");
            }

            return await _userProfileRepository.GetUserProfilesAsync(userIds, cancellationToken);
        }
    }
}
