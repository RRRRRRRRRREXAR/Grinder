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
            CreateMap<UserDTO, ProfileModel>()
                .ForMember(
                dest => dest.ProfileImage,
                opt => opt.MapFrom(src => src.ProfileImage)
                )
                .ForMember(
                dest => dest.Images,
                opt => opt.MapFrom(src => src.Images)
                );
            CreateMap<ProfileModel, UserDTO>()
                .ForMember(
                dest => dest.ProfileImage,
                opt => opt.MapFrom(src => src.ProfileImage)
                )
                .ForMember(
                dest => dest.Images,
                opt => opt.MapFrom(src => src.Images)
                );
            CreateMap<ProfileThumbnail, ThumbnailDTO>();
            CreateMap<ThumbnailDTO, ProfileThumbnail>();
            CreateMap<ProfileImage, ImageDTO>();
            CreateMap<ImageDTO, ProfileImage>();
            CreateMap<RegistrationModel, UserDTO>();
            CreateMap<UserDTO, RegistrationModel>();
            CreateMap<UpdateProfileModel, UserDTO>();
            CreateMap<UserDTO, UpdateProfileModel>();
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
                dest => dest.Sender,
                opt => opt.MapFrom(src => src.Sender)
                )
                .ForMember(
                dest => dest.Recivier,
                opt => opt.MapFrom(src => src.Recivier)
                );
            CreateMap<FriendsDTO, FriendsModel>()
                .ForMember(
                dest => dest.Sender,
                opt => opt.MapFrom(src => src.Sender)
                )
                .ForMember(
                dest => dest.Recivier,
                opt => opt.MapFrom(src => src.Recivier)
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
            CreateMap<UserDTO, FindModel>().ForMember(
                dest => dest.ProfileImage,
                opt => opt.MapFrom(src => src.ProfileImage));
            CreateMap<FindModel,UserDTO>().ForMember(
                dest => dest.ProfileImage,
                opt => opt.MapFrom(src => src.ProfileImage));
        }
    }
}
