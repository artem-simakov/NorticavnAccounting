using NorticavnAccounting.Domain.Dto;

namespace NorticavnAccounting.BLL.Interfaces;

/// <summary>
/// Service for CRUD procedures with position entities.
/// </summary>
public interface IPositionService
{
    /// <summary>
    /// Get Position by id request.
    /// </summary>
    /// <param name="id">Position Id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Position.<see cref="PositionDto"/></returns>
    Task<PositionDto> GetPositionByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Add new Employee request.
    /// </summary>
    /// <param name="position">New Position.<see cref="NewPositionDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Position.<see cref="PositionDto"/></returns>
    Task<PositionDto> CreatePositionAsync(NewPositionDto position, CancellationToken cancellationToken);

    /// <summary>
    /// Update Employee request.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="position">New Position.<see cref="NewPositionDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Position.<see cref="PositionDto"/></returns>
    Task<PositionDto> UpdatePositionByIdAsync(int id, NewPositionDto position, CancellationToken cancellationToken);

    /// <summary>
    /// Delete position request.
    /// </summary>
    /// <param name="id">Position id</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    Task DeletePositionByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Get Positions request.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Positions.<see cref="PositionDto"/></returns>
    Task<IEnumerable<PositionDto>> GetPositionsAsync(CancellationToken cancellationToken);
}