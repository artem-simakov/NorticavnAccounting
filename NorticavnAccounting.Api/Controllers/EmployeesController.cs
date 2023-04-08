using Microsoft.AspNetCore.Mvc;
using NorticavnAccounting.BLL.Interfaces;
using NorticavnAccounting.Domain.Dto;
using static System.Net.Mime.MediaTypeNames;

namespace NorticavnAccounting.Api.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    #region Fields

    private readonly IEmployeeService _employeeService;

    #endregion

    #region Ctor

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    #endregion

    #region Methods

    #region CRUD

    /// <summary>
    /// Add Employee 
    /// </summary>
    /// <example>POST: api/employees</example>
    /// <param name="employee">Employee model.<see cref="NewEmployeeDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employee.</returns>
    /// <response code="200">OK: Position.</response>
    [HttpPost("")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(Application.Json)]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] NewEmployeeDto employee,
        CancellationToken cancellationToken)
    {
        var result = await _employeeService.CreateEmployeeAsync(employee, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get employee by id.
    /// </summary>
    /// <example>GET: api/employees/1</example>
    /// <param name="id">Employee Id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employee.</returns>
    /// <response code="200">OK: employee.</response>
    /// <response code="404">Not found: If employee is missing.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(Application.Json)]
    public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _employeeService.GetEmployeeByIdAsync(id, cancellationToken);

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
    /// Update employee
    /// </summary>
    /// <example>PUT: api/employees/1</example>
    /// <param name="employee">Employee.<see cref="EmployeeDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employee.</returns>
    /// <response code="200">OK: Employee.</response>
    /// <response code="404">Not found: If employee is missing.</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(Application.Json)]
    public async Task<IActionResult> UpdateEmployeeByIdAsync(int id, [FromBody] NewEmployeeDto employee,
        CancellationToken cancellationToken)
    {
        var result = await _employeeService.UpdateEmployeeByIdAsync(id, employee, cancellationToken);

        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    /// <summary>
    /// Delete employee
    /// </summary>
    /// <example>Delete: api/employees/1</example>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <response code="204">OK.</response>
    /// <response code="404">Not found: If employee is missing.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(Application.Json)]
    public async Task<IActionResult> DeleteEmployeeByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await _employeeService.DeleteEmployeeByIdAsync(id, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Get employees 
    /// </summary>
    /// <example>GET: api/employees</example>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employees.</returns>
    /// <response code="200">OK: Employees.</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [Produces(Application.Json)]
    public async Task<IActionResult> GetEmployeesAsync(CancellationToken cancellationToken)
    {
        var result = await _employeeService.GetEmployeesAsync(cancellationToken);
        return Ok(result);
    }
    
    #endregion

    #endregion
}