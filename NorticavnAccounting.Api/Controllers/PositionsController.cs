using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NorticavnAccounting.BLL.Interfaces;
using NorticavnAccounting.Domain.Dto;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.Api.Controllers;

[Route("api/positions")]
[ApiController]
public class PositionsController : Controller
{
    #region Fields

    private readonly IPositionService _positionService;

    #endregion

    #region Ctor

    public PositionsController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    #endregion

    #region Methods

    #region CRUD

    /// <summary>
    /// Add Position 
    /// </summary>
    /// <example>POST: api/positions</example>
    /// <param name="position">Position model.<see cref="NewPositionDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Position.</returns>
    /// <response code="200">OK: Position.</response>
    [HttpPost("")]
    [ProducesResponseType(typeof(PositionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AddPositionAsync([FromBody] NewPositionDto position,
        CancellationToken cancellationToken)
    {
        var result = await _positionService.CreatePositionAsync(position, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get position by id.
    /// </summary>
    /// <example>GET: api/positions/1</example>
    /// <param name="id">Position Id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Position.</returns>
    /// <response code="200">OK: position.</response>
    /// <response code="404">Not found: If position is missing.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(PositionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetPositionByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _positionService.GetPositionByIdAsync(id, cancellationToken);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update position
    /// </summary>
    /// <example>PUT: api/positions/1</example>
    /// <param name="position">Position.<see cref="PositionDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Position.</returns>
    /// <response code="200">OK: Position.</response>
    /// <response code="404">Not found: If position is missing.</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(PositionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdatePositionByIdAsync(int id, [FromBody] NewPositionDto position,
        CancellationToken cancellationToken)
    {
        var result = await _positionService.UpdatePositionByIdAsync(id, position, cancellationToken);

        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    /// <summary>
    /// Delete position
    /// </summary>
    /// <example>Delete: api/positions/1</example>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <response code="204">OK.</response>
    /// <response code="404">Not found: If position is missing.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> DeletePositionByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await _positionService.DeletePositionByIdAsync(id, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Get positions 
    /// </summary>
    /// <example>GET: api/positions</example>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Positions.</returns>
    /// <response code="200">OK: Positions.</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(PositionDto), StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetPositionsAsync(CancellationToken cancellationToken)
    {
        var result = await _positionService.GetPositionsAsync(cancellationToken);
        return Ok(result);
    }

    #endregion

    #endregion
}