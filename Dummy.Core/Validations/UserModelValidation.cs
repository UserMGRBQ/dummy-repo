using Dummy.Core.Models;
using Dummy.Core.Utilities;
using Dummy.Core.Validations.Base;
using FluentValidation;

namespace Dummy.Core.Validations;

public class UserModelValidation : AbstractValidator<UserModel>
{
	public UserModelValidation()
	{
		RuleFor(u => u.Name).NotEmpty().NotNull().WithMessage("The user name must be informed");
		RuleFor(u => u.Email).Must(StringUtil.ValidateEmail).WithMessage("Email informed is invalid").NotEmpty().NotNull().WithMessage("The user email must be informed");
		RuleFor(u => u.Document).Must(BaseValidations.BeValidDocument).WithMessage("Document informed is invalid");
    }
}