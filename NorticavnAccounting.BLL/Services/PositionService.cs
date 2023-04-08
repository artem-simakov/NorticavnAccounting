using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NorticavnAccounting.BLL.Interfaces;
using NorticavnAccounting.DAL.Contexts;
using NorticavnAccounting.Domain.Dto;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.BLL.Services;

public class PositionService : IPositionService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly NorticavnAccountingDbContext _dbContext;

    #endregion

    #region Ctor

    public PositionService(IMapper mapper, NorticavnAccountingDbContext dbContext)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<PositionDto> GetPositionByIdAsync(int id, CancellationToken cancellationToken)
    {
        var position = await _dbContext.Positions.Include(x => x.Employees)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        var model = _mapper.Map<PositionDto>(position);

        return model;
    }

    /// <inheritdoc />
    public async Task<PositionDto> CreatePositionAsync(NewPositionDto position, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Position>(position);

        await _dbContext.Positions.AddAsync(model, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var newPosition = _mapper.Map<PositionDto>(position);
        newPosition.Id = model.Id;

        return newPosition;
    }

    /// <inheritdoc />
    public async Task<PositionDto> UpdatePositionByIdAsync(int id, NewPositionDto position,
        CancellationToken cancellationToken)
    {
        var model = await _dbContext.Positions.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        _mapper.Map(position, model);

        if (model != null)
        {
            _dbContext.Positions.Update(model);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        var result = _mapper.Map<PositionDto>(position);

        return result;
    }

    /// <inheritdoc />
    public async Task DeletePositionByIdAsync(int id, CancellationToken cancellationToken)
    {
        var model = await _dbContext.Positions.Include(x => x.Employees)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (model != null && !model.Employees.Any())
        {
            _dbContext.Positions.Remove(model);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    /// <inheritdoc />
    public async Task<IEnumerable<PositionDto>> GetPositionsAsync(CancellationToken cancellationToken)
    {
        var positions = await _dbContext.Positions.Include(x => x.Employees)
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

        var model = _mapper.Map<IEnumerable<PositionDto>>(positions);

        return model;
    }

    #endregion
}