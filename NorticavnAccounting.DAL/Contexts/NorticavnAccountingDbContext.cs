using Microsoft.EntityFrameworkCore;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.DAL.Contexts;

public class NorticavnAccountingDbContext : DbContext
{
    #region Ctor

    /// <summary>
    /// Used for ef bulk.
    /// </summary>
    public NorticavnAccountingDbContext(DbContextOptions options) : base(options)
    {
    }

    public NorticavnAccountingDbContext()
    {
    }

    #endregion

    #region Entities

    /// <inheritdoc cref="Employee" />
    public virtual DbSet<Employee> Employees { get; set; }

    /// <inheritdoc cref="Position" />
    public virtual DbSet<Position> Positions { get; set; }

    #endregion
}