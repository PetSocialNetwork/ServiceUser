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

        public async Task<UserProfile> AddUserProfileAsync(Guid accountId, CancellationToken cancellationToken)
        {
            if (!IsAddUserProfileAvailable(accountId, cancellationToken))
            {
                throw new UserProfileWithAccountAlreadyExistsException("У данного аккаунта профиль уже существует.");
            };

            UserProfile userProfile = new UserProfile(Guid.NewGuid(), accountId);

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

            await _userProfileRepository.Update(userProfile, cancellationToken);
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

        public async Task<Guid> DeleteUserProfileByAccountIdAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var existedProfile = await _userProfileRepository.FindUserProfileByAccountIdAsync(accountId, cancellationToken);
            if (existedProfile is null)
            {
                throw new UserProfileNotFoundException("Пользователя с таким профилем не существует.");
            }

            await _userProfileRepository.Delete(existedProfile, cancellationToken);
            //как быть
            //return existedProfile.PetId;
            return Guid.Empty;
        }

        private bool IsAddUserProfileAvailable(Guid accountId, CancellationToken cancellationToken)
        {
            try
            {
                var existedUserProfile = _userProfileRepository.FindUserProfileByAccountIdAsync(accountId, cancellationToken);
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
    }
}
