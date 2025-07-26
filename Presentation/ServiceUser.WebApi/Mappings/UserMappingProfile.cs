using AutoMapper;
using ServiceUser.Domain.Entities;
using ServiceUser.Domain.Shared;
using ServiceUser.WebApi.Models.Requests;
using ServiceUser.WebApi.Models.Responses;

namespace ServiceUser.WebApi.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserProfile, UserProfileResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.WalksDogs, opt => opt.MapFrom(src => src.WalksDogs))
                .ForMember(dest => dest.Profession, opt => opt.MapFrom(src => src.Profession))
                .ForMember(dest => dest.AboutSelf, opt => opt.MapFrom(src => src.AboutSelf))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.Interests))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.IsProfileCompleted, opt => opt.MapFrom(src => src.IsProfileCompleted));

            CreateMap<AddUserProfileRequest, UserProfile>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
               .ForMember(dest => dest.IsProfileCompleted, opt => opt.MapFrom(src => false));

            CreateMap<UpdateUserProfileRequest, UserProfile>();
            CreateMap<PaginationRequest, PaginationOptions>();
        }
    }
}
