using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.BLL.MapProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(
                dest=>dest.ProfileImage,
                opt=>opt.MapFrom(src=>src.ProfileImage)
                )
                .ForMember(
                dest=>dest.Images,
                opt=>opt.MapFrom(src=>src.Images)
                );
            CreateMap<User, UserDTO>()
                .ForMember(
                dest => dest.ProfileImage,
                opt => opt.MapFrom(src => src.ProfileImage)
                )
                .ForMember(
                dest => dest.Images,
                opt => opt.MapFrom(src => src.Images)
                );
            CreateMap<Image, ImageDTO>().
                ForMember(
                dest=>dest.UserId,
                opt=>opt.MapFrom(src=>src.UserId)
                );
            CreateMap<ImageDTO, Image>().
                ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId)
                );
            CreateMap<Friends, FriendsDTO>()
                .ForMember(
                dest=>dest.Sender,
                opt=>opt.MapFrom(src=>src.Sender)
                )
                .ForMember(
                dest=>dest.Recivier,
                opt=>opt.MapFrom(src=>src.Recivier)
                );
            CreateMap<FriendsDTO, Friends>()
                .ForMember(
                dest => dest.Sender,
                opt => opt.MapFrom(src => src.Sender)
                )
                .ForMember(
                dest => dest.Recivier,
                opt => opt.MapFrom(src => src.Recivier)
                );
            CreateMap<Message, MessageDTO>().
                ForMember(
                des => des.Recivier,
                opt => opt.MapFrom(src => src.Recivier)).
                ForMember(
                dest => dest.Sender,
                opt => opt.MapFrom(src => src.Sender));
            CreateMap<MessageDTO, Message>().
                ForMember(
                des => des.Recivier,
                opt => opt.MapFrom(src => src.Recivier)).
                ForMember(
                dest => dest.Sender,
                opt => opt.MapFrom(src => src.Sender));
            CreateMap<Thumbnail, ThumbnailDTO>().
                ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId)
                );
            CreateMap<ThumbnailDTO, Thumbnail>().
                ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId)
                );
            CreateMap<ProfileView, ProfileViewDTO>().
                ForMember(
                dest => dest.Profile,
                opt => opt.MapFrom(src => src.Profile)
                ).
                ForMember(
                dest => dest.Viewer,
                opt => opt.MapFrom(src=>src.Viewer)
                );
            CreateMap<ProfileViewDTO, ProfileView>().
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
