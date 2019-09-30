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
            CreateMap<Image, ImageDTO>();
            CreateMap<ImageDTO, Image>();
            CreateMap<Friends, FriendsDTO>()
                .ForMember(
                dest=>dest.User1,
                opt=>opt.MapFrom(src=>src.User1)
                )
                .ForMember(
                dest=>dest.User2,
                opt=>opt.MapFrom(src=>src.User2)
                );
            CreateMap<FriendsDTO, Friends>()
                .ForMember(
                dest => dest.User1,
                opt => opt.MapFrom(src => src.User1)
                )
                .ForMember(
                dest => dest.User2,
                opt => opt.MapFrom(src => src.User2)
                );
        }
    }
}
