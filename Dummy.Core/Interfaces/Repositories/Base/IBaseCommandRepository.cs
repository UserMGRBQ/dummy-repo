using Dummy.Core.Abstract.Entity;

namespace Dummy.Core.Interfaces.Repositories.Base;

public interface IBaseCommandRepository<T, Tid>
    where T : AbstractEntity<T, Tid>
    where Tid : IEquatable<Tid>
{
    Task AddAsync(T entity);

    Task RemoveAsync(T entity);

    Task UpdateAsync(T entity);

    Task Commit();
}