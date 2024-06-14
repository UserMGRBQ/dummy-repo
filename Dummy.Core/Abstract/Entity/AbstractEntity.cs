using Dummy.Core.Interfaces.Results;

namespace Dummy.Core.Abstract.Entity;

public abstract class AbstractEntity<TEntity, TId>
    where TEntity : AbstractEntity<TEntity, TId>
    where TId : IEquatable<TId>
{
    public abstract TId Id { get; set; }

    public abstract IOperationResult<TEntity> IsValid();

    public abstract TEntity Sanitize();
}