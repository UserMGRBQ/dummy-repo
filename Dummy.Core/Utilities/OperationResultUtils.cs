using Dummy.Core.Interfaces.Results;
using Dummy.Core.Results;
using FluentValidation.Results;

namespace Dummy.Core.Utilities;

public static class OperationResultUtils
{
    public static IOperationResult<T> ToOperationResult<T>(this ValidationResult result, T obj) 
    {
        if (result.IsValid)
            return OperationResult<T>.CreateSuccess(obj);
        else
            return OperationResult<T>.CreateInvalidInput().AddMessages(result.Errors.ToOperationResultMessages());
    }

    private static List<string> ToOperationResultMessages(this List<ValidationFailure> errors) 
    {
        var response = new List<string>();

        foreach (var error in errors)
        {
            response.Add(error.ErrorMessage);
        }
        
        return response;
    }
}