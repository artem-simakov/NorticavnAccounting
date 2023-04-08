using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.Domain.Dto;

/// <summary>
/// DTO of Employee entity for Employee service.
/// </summary>
public class EmployeeDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// First Name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last Name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Father Name.
    /// </summary>
    public string FatherName { get; set; }

    /// <summary>
    /// Positions.
    /// </summary>
    public IEnumerable<Position> Positions { get; set; }
}