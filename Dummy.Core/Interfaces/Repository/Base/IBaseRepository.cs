using System.Linq.Expressions;

namespace Dummy.Core.Interfaces.Repository.Base;

public interface IBaseRepository<T, Tid> 
    where T : class
    where Tid : IEquatable<Tid>
{
    Task AddAsync(T entity);

    Task<T> GetByIdAsync(Tid id);

    IQueryable<T> GetAll();

    Task RemoveAsync(T entity);

    Task UpdateAsync(T entity);

    Task Commit();
}