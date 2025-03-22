using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceUser.Domain.Entities;
using ServiceUser.Domain.Services;
using ServiceUser.WebApi.Models.Requests;
using ServiceUser.WebApi.Models.Responses;

namespace ServiceUser.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileService _userProfileService;
        private readonly IMapper _mapper;
        public UserProfileController(UserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService ?? throw new ArgumentException(nameof(userProfileService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("[action]")]
        public async Task<UserProfileResponse> GetUserProfileByIdAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileService.GetUserProfileByIdAsync(id, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);  
        }

        [HttpGet("[action]")]
        public async Task<UserProfileResponse> GetUserProfileByAccountIdAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileService.GetUserProfileByAccountIdAsync(id, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);
        }

        [HttpDelete("[action]")]
        public async Task DeleteUserProfileAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _userProfileService.DeleteUserProfileAsync(id, cancellationToken);
        }

        [HttpDelete("[action]")]
        public async Task DeleteUserProfileByAccountIdAsync([FromQuery] Guid accountId, CancellationToken cancellationToken)
        {
            await _userProfileService.DeleteUserProfileByAccountIdAsync(accountId, cancellationToken);
        }

        [HttpPost("[action]")]
        public async Task<UserProfileResponse> AddUserProfileAsync([FromBody] AddUserProfileRequest request,CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileService.AddUserProfileAsync(request.AccountId, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);
        }

        [HttpPut("[action]")]
        public async Task UpdateUserProfileAsync([FromBody] UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var userProfile = _mapper.Map<UserProfile>(request);
            await _userProfileService.UpdateUserProfileAsync(userProfile, cancellationToken);
        }

        [HttpGet("[action]")]
        public async Task<List<UserProfileResponse>> FindUserProfileByNameAsync([FromQuery] string firstName, [FromQuery] string lastName, CancellationToken cancellationToken)
        {
            var profiles = await _userProfileService
                .FindUserProfileByNameAsync(firstName, lastName, cancellationToken);
            return _mapper.Map<List<UserProfileResponse>>(profiles);
        }

        [HttpGet("[action]")]
        public async Task<List<UserProfileResponse>> GetUserProfilesAsync([FromBody] List<Guid> userIds, CancellationToken cancellationToken)
        {
            var profiles = await _userProfileService
                .GetUserProfilesAsync(userIds, cancellationToken);
            return _mapper.Map<List<UserProfileResponse>>(profiles);
        }
    }
}
