﻿namespace Dummy.Core.Interfaces.Repository.Base;

public interface IBaseCommandRepository<T, Tid>
    where T : class
    where Tid : IEquatable<Tid>
{
    Task AddAsync(T entity);

    Task RemoveAsync(T entity);

    Task UpdateAsync(T entity);

    Task Commit();
}