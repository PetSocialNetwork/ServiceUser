using AutoMapper;
using ServiceUser.Domain.Entities;
using ServiceUser.WebApi.Models.Requests;
using ServiceUser.WebApi.Models.Responses;

namespace ServiceUser.WebApi.Mappings
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfile, UserProfileResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.WalksDogs, opt => opt.MapFrom(src => src.WalksDogs))
                .ForMember(dest => dest.Profession, opt => opt.MapFrom(src => src.Profession))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.IsProfileCompleted, opt => opt.MapFrom(src => src.IsProfileCompleted));

            CreateMap<UpdateUserProfileRequest, UserProfile>();
        }
    }
}
