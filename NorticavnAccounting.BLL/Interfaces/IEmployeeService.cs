using NorticavnAccounting.Domain.Dto;

namespace NorticavnAccounting.BLL.Interfaces;

/// <summary>
/// Service for CRUD procedures with employee entities.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Get Employee by id request.
    /// </summary>
    /// <param name="id">Employee Id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employee.<see cref="EmployeeDto"/></returns>
    Task<EmployeeDto> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Add new Employee request.
    /// </summary>
    /// <param name="employee">New Employee.<see cref="NewEmployeeDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employee.<see cref="EmployeeDto"/></returns>
    Task<EmployeeDto> CreateEmployeeAsync(NewEmployeeDto employee, CancellationToken cancellationToken);

    /// <summary>
    /// Update Employee request.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="employee">New Employee.<see cref="NewEmployeeDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employee.<see cref="EmployeeDto"/></returns>
    Task<EmployeeDto> UpdateEmployeeByIdAsync(int id, NewEmployeeDto employee, CancellationToken cancellationToken);

    /// <summary>
    /// Delete employee request.
    /// </summary>
    /// <param name="id">Employee id</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    Task DeleteEmployeeByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Get Employees request.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Employees.<see cref="EmployeeDto"/></returns>
    Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(CancellationToken cancellationToken);
}