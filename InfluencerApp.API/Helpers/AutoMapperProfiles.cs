using System.Linq;
using AutoMapper;
using InfluencerApp.API.Dtos;
using InfluencerApp.API.Models;

namespace InfluencerApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.MainPhoto).Url);
                });
            CreateMap<User, UserDetailsDto>()
             .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.MainPhoto).Url);
                });
            CreateMap<Photo, PhotosForDetails>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}