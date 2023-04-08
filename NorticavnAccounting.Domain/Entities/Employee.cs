using NorticavnAccounting.Domain.Interfaces;

namespace NorticavnAccounting.Domain.Entities;

/// <summary>
/// Employee entity.
/// </summary>
public class Employee : IBaseEntity<int>
{
    #region Properties

    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// FirstName.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// LastName.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// FatherName.
    /// </summary>
    public string FatherName { get; set; }

    #endregion

    #region FK

    /// <summary>
    /// Navigation Property to related Position entities.
    /// </summary>
    public ICollection<Position> Positions { get; set; }

    #endregion
}