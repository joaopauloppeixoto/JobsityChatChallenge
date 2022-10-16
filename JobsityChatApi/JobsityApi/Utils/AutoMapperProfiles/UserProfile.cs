using AutoMapper;
using JobsityApi.Services;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace JobsityApi.Utils.AutoMapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        var hash = new Hash(SHA512.Create());
        CreateMap<NewUserViewModel, IdentityUser>()
            .ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(src => hash.PasswordHash(src.Password))
            )
            .ForMember(
                dest => dest.NormalizedEmail,
                opt => opt.MapFrom(src => src.Email.ToUpper())
            )
            .ForMember(
                dest => dest.NormalizedUserName,
                opt => opt.MapFrom(src => src.UserName.ToUpper())
            );

        CreateMap<AuthViewModel, IdentityUser>()
            .ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(src => hash.PasswordHash(src.Password))
            )
            .ForMember(
                dest => dest.NormalizedEmail,
                opt => opt.MapFrom(src => src.Email.ToUpper())
            );

        CreateMap<IdentityUser, UserViewModel>()
            .ForMember(
                dest => dest.Nickname,
                opt => opt.MapFrom(src => src.UserName)
            );
    }
}
