using NorticavnAccounting.Domain.Enum;
using NorticavnAccounting.Domain.Interfaces;

namespace NorticavnAccounting.Domain.Entities;

public class Position : IBaseEntity<int>
{
    #region Properties

    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// JobTitle.
    /// </summary>
    public string JobTitle { get; set; }

    /// <summary>
    /// Grade.
    /// </summary>
    public Grade Grade { get; set; }

    #endregion

    #region FK

    /// <summary>
    /// Navigation Property to related Employee entities.
    /// </summary>
    public ICollection<Employee> Employees { get; set; }

    #endregion
}