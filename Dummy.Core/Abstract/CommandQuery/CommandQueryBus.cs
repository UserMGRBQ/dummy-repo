using Dummy.Core.Abstract.Entity;

namespace Dummy.Core.Abstract.CommandQuery;

public abstract class CommandQueryBus<TDto, TModel, TId>
    where TModel : AbstractEntity<TModel, TId>
    where TDto : CQSDto<TModel, TId>
    where TId : IEquatable<TId>
{
    public abstract TDto Dto { get; }
}