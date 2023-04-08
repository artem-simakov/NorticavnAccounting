using NorticavnAccounting.Domain.Entities;
using NorticavnAccounting.Domain.Enum;

namespace NorticavnAccounting.Domain.Dto;

/// <summary>
/// DTO of Position entity for Position service.
/// </summary>
public class PositionDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Job Title.
    /// </summary>
    public string JobTitle { get; set; }
    
    /// <summary>
    /// Grade.
    /// </summary>
    public Grade Grade { get; set; }
    
    /// <summary>
    /// Employees.
    /// </summary>
    public IEnumerable<Employee> Employees { get; set; }
}