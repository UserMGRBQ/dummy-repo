using AutoMapper;
using Dummy.CQS.Commands.User;
using Dummy.CQS.Dtos;
using Dummy.CQS.Objects;

namespace Dummy.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserObj, UserDto>();
        CreateMap<UserDto, CreateUserCommand>();
    }
}