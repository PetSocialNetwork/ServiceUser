using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceUser.Domain.Entities;
using ServiceUser.Domain.Services;
using ServiceUser.Domain.Shared;
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
            _userProfileService = userProfileService 
                ?? throw new ArgumentException(nameof(userProfileService));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Возвращает профиль пользователя по идентификатору профиля
        /// </summary>
        /// <param name="id">Идентификатор профиля</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<UserProfileResponse> GetUserProfileByIdAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileService.GetUserProfileByIdAsync(id, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);  
        }

        /// <summary>
        /// Возвращает профиль пользователя по идентификатору аккаунта
        /// </summary>
        /// <param name="id">Идентификатор аккаунта</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<UserProfileResponse> GetUserProfileByAccountIdAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileService.GetUserProfileByAccountIdAsync(id, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);
        }

        /// <summary>
        /// Удаляет профиль пользователя по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор профиля</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpDelete("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task DeleteUserProfileAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _userProfileService.DeleteUserProfileAsync(id, cancellationToken);
        }

        /// <summary>
        ///  Удаляет профиль пользователя по идентификатору аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpDelete("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task DeleteUserProfileByAccountIdAsync
            ([FromQuery] Guid accountId, CancellationToken cancellationToken)
        {
            await _userProfileService.DeleteUserProfileByAccountIdAsync(accountId, cancellationToken);
        }

        /// <summary>
        /// Добавляет профиль пользователя
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<UserProfileResponse> AddUserProfileAsync
            ([FromBody] AddUserProfileRequest request,CancellationToken cancellationToken)
        {
            var profile = _mapper.Map<UserProfile>(request);
            var userProfile = await _userProfileService.AddUserProfileAsync(profile, cancellationToken);
            return _mapper.Map<UserProfileResponse>(userProfile);
        }

        /// <summary>
        /// Обновляет профиль пользователя
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPut("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task UpdateUserProfileAsync
            ([FromBody] UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var userProfile = _mapper.Map<UserProfile>(request);
            await _userProfileService.UpdateUserProfileAsync(userProfile, cancellationToken);
        }

        /// <summary>
        /// Возвращает найденные профили по имени
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<UserProfileResponse>> FindUserProfileByNameAsync
            ([FromBody] FindUserProfileRequest request, CancellationToken cancellationToken)
        {
            var options = _mapper.Map<PaginationOptions>(request.Options);
            var profiles = await _userProfileService
                .FindUserProfileByNameAsync(request.FirstName, request.LastName, options, cancellationToken);
            return _mapper.Map<List<UserProfileResponse>>(profiles);
        }

        /// <summary>
        /// Возвращает профили пользователей по идентифкаторам
        /// </summary>
        /// <param name="userIds">Массим идентификаторов пользователей</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<UserProfileResponse>> GetUserProfilesAsync
            ([FromBody] List<Guid> userIds, CancellationToken cancellationToken)
        {
            var profiles = await _userProfileService
                .GetUserProfilesAsync(userIds, cancellationToken);
            return _mapper.Map<List<UserProfileResponse>>(profiles);
        }
    }
}
