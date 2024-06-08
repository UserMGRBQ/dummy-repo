using Dummy.Core.Interfaces.Results;
using Dummy.Core.Utilities;
using Dummy.Core.Validations;

namespace Dummy.Core.Models;

public class UserModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }

    public UserModel(string name, string email, string document)
    {
        Name = name;
        Email = email;
        Document = document;
    }

    public IOperationResult<UserModel> IsValidUser() 
    {
        return new UserModelValidation().Validate(this).ToOperationResult(this);
    }
}