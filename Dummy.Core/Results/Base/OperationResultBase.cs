using Dummy.Core.Enums;
using Dummy.Core.Interfaces.Results;

namespace Dummy.Core.Results.Base;

public class OperationResultBase : IOperationResultBase
{
    public List<string> Messages { get; set; }
    public EnumResultType ResultType { get; set; }
    public Exception Exception { get; set; }
    public bool IsSuccessResultType => _IsSuccessResultType(ResultType);

    public OperationResultBase(EnumResultType resultType) 
    { 
        ResultType = resultType; 
    }

    public OperationResultBase(IOperationResultBase otherResult)
    {
        Messages = otherResult.Messages;
        ResultType = otherResult.ResultType;
        Exception = otherResult.Exception;
    }

    public OperationResultBase(EnumResultType resultType, Exception exception)
    {
        ResultType = resultType;
        Exception = exception;
    }

    public static IOperationResultBase Create(EnumResultType resultType)
        => new OperationResultBase(resultType);

    public static IOperationResultBase Create(IOperationResultBase otherResult)
        => new OperationResultBase(otherResult);

    public static IOperationResultBase CreateSuccess()
        => new OperationResultBase(EnumResultType.Ok);

    public static IOperationResultBase CreateCreated()
        => new OperationResultBase(EnumResultType.Created);

    public static IOperationResultBase CreateConflict()
        => new OperationResultBase(EnumResultType.Conflict);

    public static IOperationResultBase CreateInvalidInput()
        => new OperationResultBase(EnumResultType.InvalidInput);

    public static IOperationResultBase CreateServiceUnavailable()
        => new OperationResultBase(EnumResultType.ServiceUnavailable);

    public static IOperationResultBase CreateNotFound()
        => new OperationResultBase(EnumResultType.NotFound);

    public static IOperationResultBase CreateInternalServerError()
        => new OperationResultBase(EnumResultType.InternalServerError);

    public static IOperationResultBase CreateInternalServerError(Exception exception)
        => new OperationResultBase(EnumResultType.InternalServerError) { Exception = exception };

    public IOperationResultBase AddMessage(string message)
    {
        _AddMessage(message);
        return this;
    }

    public IOperationResultBase AddMessages(IEnumerable<string> messages)
    {
        _AddMessages(messages);
        return this;
    }

    private static bool _IsSuccessResultType(EnumResultType resultType)
    {
        return resultType switch
        {
            EnumResultType.Ok or EnumResultType.Created or EnumResultType.Accepted or EnumResultType.NoContent => true,
            _ => false,
        };
    }

    protected void _AddMessage(string message)
    {
        Messages ??= [];
        Messages.Add(message);
    }

    protected void _AddMessages(IEnumerable<string> messages)
    {
        if (messages is null)
            return;

        Messages ??= [];
        Messages.AddRange(messages);
    }
}