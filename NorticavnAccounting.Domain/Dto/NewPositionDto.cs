using NorticavnAccounting.Domain.Entities;
using NorticavnAccounting.Domain.Enum;

namespace NorticavnAccounting.Domain.Dto;

/// <summary>
/// DTO of new Position entity for Position service.
/// </summary>
public class NewPositionDto
{
    /// <summary>
    /// Job Title.
    /// </summary>
    public string JobTitle { get; set; }
    
    /// <summary>
    /// Grade.
    /// </summary>
    public Grade Grade { get; set; }
}