using Dummy.Core.Enums;
using Dummy.Core.Interfaces.Results;
using Dummy.Core.Results.Base;

namespace Dummy.Core.Results;

public class OperationResult<T> : OperationResultBase, IOperationResult<T>
{
    public T Data { get; set; }

    public OperationResult(EnumResultType resultType) : base(resultType) { }

    protected OperationResult(IOperationResultBase otherResult) : base(otherResult) { }

    protected OperationResult(EnumResultType resultType, Exception exception) : base(resultType, exception) { }

    protected OperationResult(EnumResultType resultType, T result) : base(resultType) { Data = result; }

    public static IOperationResult<T> Create(EnumResultType resultType, T data)
        => new OperationResult<T>(resultType, data);

    public new static IOperationResult<T> Create(IOperationResultBase otherResult)
        => new OperationResult<T>(otherResult);

    public new static IOperationResult<T> Create(EnumResultType resultType)
        => new OperationResult<T>(resultType);

    public static IOperationResult<T> CreateSuccess(T data)
        => new OperationResult<T>(EnumResultType.Ok, data);

    public static IOperationResult<T> CreateCreated(T data)
        => new OperationResult<T>(EnumResultType.Created, data);

    public new static IOperationResult<T> CreateInvalidInput()
        => new OperationResult<T>(EnumResultType.InvalidInput);

    public new static IOperationResult<T> CreateConflict()
        => new OperationResult<T>(EnumResultType.Conflict);

    public new static IOperationResult<T> CreateServiceUnavailable()
        => new OperationResult<T>(EnumResultType.ServiceUnavailable);

    public new static IOperationResult<T> CreateNotFound()
        => new OperationResult<T>(EnumResultType.NotFound);

    public new static IOperationResult<T> CreateInternalServerError()
        => new OperationResult<T>(EnumResultType.InternalServerError);

    public new static IOperationResult<T> CreateInternalServerError(Exception exception)
        => new OperationResult<T>(EnumResultType.InternalServerError) { Exception = exception };

    public new IOperationResult<T> AddMessage(string message) { _AddMessage(message); return this; }

    public new IOperationResult<T> AddMessages(IEnumerable<string> messages) { _AddMessages(messages); return this; }
}