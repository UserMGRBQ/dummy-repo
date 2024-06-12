using Dummy.Core.Abstract.Entity;
using Dummy.Core.Interfaces.Results;
using Dummy.Core.Utilities;
using Dummy.Core.Validations;

namespace Dummy.Core.Models;

public class UserModel : AbstractEntity<UserModel, int>
{
    public override int Id { get; set; }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }

    public UserModel(string name, string email, string document)
    {
        Name = name;
        Email = email;
        Document = document;
    }

    public override IOperationResult<UserModel> IsValid() 
    {
        return new UserModelValidation().Validate(this).ToOperationResult(this);
    }

    public override UserModel Sanitize()
    {
        Document = Document.ExtractNumbers();

        return this;
    }
}