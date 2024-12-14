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

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UserProfileNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]")]
        public async Task<UserProfileResponse> GetUserProfileByIdAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileService.GetUserProfileByIdAsync(id, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);  
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UserProfileNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[action]")]
        public async Task DeleteUserProfileAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _userProfileService.DeleteUserProfileAsync(id, cancellationToken);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UserProfileNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[action]")]
        public async Task DeleteUserProfileByAccountIdAsync([FromQuery] Guid accountId, CancellationToken cancellationToken)
        {
            await _userProfileService.DeleteUserProfileByAccountIdAsync(accountId, cancellationToken);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UserProfileWithAccountAlreadyExistsException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("[action]")]
        public async Task<UserProfileResponse> AddUserProfileAsync([FromBody] AddUserProfileRequest request,CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileService.AddUserProfileAsync(request.AccountId, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UserProfileNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("[action]")]
        public async Task UpdateUserProfileAsync([FromBody] UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var userProfile = _mapper.Map<UserProfile>(request);
            await _userProfileService.UpdateUserProfileAsync(userProfile, cancellationToken);
        }
    }
}
