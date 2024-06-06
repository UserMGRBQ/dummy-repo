using Dummy.Core.Models;
using Dummy.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dummy.Persistence.Contexts;

public class DummyContext(DbContextOptions opt) : DbContext(opt)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}