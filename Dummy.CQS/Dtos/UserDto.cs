using Dummy.Core.Abstract.CommandQuery;
using Dummy.Core.Models;

namespace Dummy.CQS.Dtos;

public class UserDto : CQSDto<UserModel, int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
}