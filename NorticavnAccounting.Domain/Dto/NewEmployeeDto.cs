using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.Domain.Dto;

/// <summary>
/// DTO of new Employee entity for Employee service.
/// </summary>
public class NewEmployeeDto
{
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
    
    /// <summary>
    /// Position Ids.
    /// </summary>
    public int[] PositionIds { get; set; }
}