using AutoMapper;
using Dummy.CQS.Commands.User;
using Dummy.CQS.Dtos;

namespace Dummy.Api.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UserDto, CreateUserCommand>();
	}
}
