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
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opt => opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.MainPhoto).Url))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.MainPhoto).Url));
        }
    }
}