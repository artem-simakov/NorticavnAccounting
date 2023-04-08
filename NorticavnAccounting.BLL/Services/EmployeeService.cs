using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NorticavnAccounting.BLL.Interfaces;
using NorticavnAccounting.DAL.Contexts;
using NorticavnAccounting.Domain.Dto;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.BLL.Services;

public class EmployeeService : IEmployeeService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly NorticavnAccountingDbContext _dbContext;

    #endregion

    #region Ctor

    public EmployeeService(IMapper mapper, NorticavnAccountingDbContext dbContext)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.Employees.Include(x => x.Positions)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        var model = _mapper.Map<EmployeeDto>(employee);

        return model;
    }

    /// <inheritdoc />
    public async Task<EmployeeDto> CreateEmployeeAsync(NewEmployeeDto employee, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Employee>(employee);

        if (employee.PositionIds.Length != 0)
        {
            var positions = await _dbContext.Positions.Where(x => employee.PositionIds.Contains(x.Id))
                .ToArrayAsync(cancellationToken);

            model.Positions = positions;
        }

        await _dbContext.Employees.AddAsync(model, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var newEmployee = _mapper.Map<EmployeeDto>(employee);
        newEmployee.Id = model.Id;

        return newEmployee;
    }

    /// <inheritdoc />
    public async Task<EmployeeDto> UpdateEmployeeByIdAsync(int id, NewEmployeeDto employee,
        CancellationToken cancellationToken)
    {
        var model = await _dbContext.Employees.Include(x => x.Positions)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (model != null)
        {
            if (employee.PositionIds.Length != 0)
            {
                var positions = _dbContext.Positions.Where(x => employee.PositionIds.Contains(x.Id))
                    .ToArray();

                model.Positions.Clear();

                foreach (var position in positions)
                    model.Positions.Add(position);
            }

            _dbContext.Employees.Update(model);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        var result = _mapper.Map<EmployeeDto>(model);
        
        
        return result;
    }

    /// <inheritdoc />
    public async Task DeleteEmployeeByIdAsync(int id, CancellationToken cancellationToken)
    {
        var model = await _dbContext.Employees.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (model != null)
        {
            _dbContext.Employees.Remove(model);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    /// <inheritdoc />
    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(CancellationToken cancellationToken)
    {
        var employees = await _dbContext.Employees.Include(x => x.Positions)
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

        var model = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

        return model;
    }

    #endregion
}