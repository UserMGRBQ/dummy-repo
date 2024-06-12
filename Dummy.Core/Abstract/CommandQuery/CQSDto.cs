using Dummy.Core.Abstract.Entity;

namespace Dummy.Core.Abstract.CommandQuery;

public abstract class CQSDto<TModel, TId>
    where TModel : AbstractEntity<TModel, TId>
    where TId : IEquatable<TId>
{
}