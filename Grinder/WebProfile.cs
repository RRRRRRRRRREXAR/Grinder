using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder
{
    public class WebProfile:Profile
    {
        public WebProfile()
        {
            CreateMap<UserDTO, UserModel>()
                .ForMember(
                dest => dest.ProfileImage,
                opt => opt.MapFrom(src => src.ProfileImage)
                )
                .ForMember(
                dest => dest.Images,
                opt => opt.MapFrom(src => src.Images)
                );
            CreateMap<UserModel, UserDTO>()
                .ForMember(
                dest => dest.ProfileImage,
                opt => opt.MapFrom(src => src.ProfileImage)
                )
                .ForMember(
                dest => dest.Images,
                opt => opt.MapFrom(src => src.Images)
                );
            CreateMap<RegistrationModel, UserDTO>();
            CreateMap<UserDTO, RegistrationModel>();
            CreateMap<ImageModel, ImageDTO>().
                ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId)
                );
            CreateMap<ImageDTO, ImageModel>().
                ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId)
                );
            CreateMap<FriendsModel, FriendsDTO>()
                .ForMember(
                dest => dest.User1,
                opt => opt.MapFrom(src => src.User1)
                )
                .ForMember(
                dest => dest.User2,
                opt => opt.MapFrom(src => src.User2)
                );
            CreateMap<FriendsDTO, FriendsModel>()
                .ForMember(
                dest => dest.User1,
                opt => opt.MapFrom(src => src.User1)
                )
                .ForMember(
                dest => dest.User2,
                opt => opt.MapFrom(src => src.User2)
                );
            CreateMap<MessageModel, MessageDTO>().
                ForMember(
                des => des.Recivier,
                opt => opt.MapFrom(src => src.Recivier)).
                ForMember(
                dest => dest.Sender,
                opt => opt.MapFrom(src => src.Sender));
            CreateMap<MessageDTO, MessageModel>().
                ForMember(
                des => des.Recivier,
                opt => opt.MapFrom(src => src.Recivier)).
                ForMember(
                dest => dest.Sender,
                opt => opt.MapFrom(src => src.Sender));
            CreateMap<ThumbnailModel, ThumbnailDTO>().
                ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId)
                );
            CreateMap<ThumbnailDTO, ThumbnailModel>().
                ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId)
                );
            CreateMap<ProfileViewModel, ProfileViewDTO>().
                ForMember(
                dest => dest.Profile,
                opt => opt.MapFrom(src => src.Profile)
                ).
                ForMember(
                dest => dest.Viewer,
                opt => opt.MapFrom(src => src.Viewer)
                );
            CreateMap<ProfileViewDTO, ProfileViewModel>().
                ForMember(
                dest => dest.Profile,
                opt => opt.MapFrom(src => src.Profile)
                ).
                ForMember(
                dest => dest.Viewer,
                opt => opt.MapFrom(src => src.Viewer)
                );
        }
    }
}
