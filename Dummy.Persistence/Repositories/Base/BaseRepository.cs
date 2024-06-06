﻿using Dummy.Core.Interfaces.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dummy.Persistence.Repositories.Base;

public class BaseRepository<T, Tid>(DbContext context) : IBaseRepository<T, Tid>
    where T : class
    where Tid : IEquatable<Tid>
{
    protected readonly DbContext Db = context ?? throw new ArgumentNullException("There has been an error while trying to create a connection.");
    protected readonly DbSet<T> DbSet = context.Set<T>();

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Db.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(Tid id)
    {
        return await DbSet.FindAsync(id);
    }

    public IQueryable<T> GetAll()
    {
        return DbSet;
    }

    public async Task RemoveAsync(T entity)
    {
        DbSet.Remove(entity);
        await Db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Db.SaveChangesAsync();
    }

    public async Task Commit()
    {
        await Db.SaveChangesAsync();
    }
}