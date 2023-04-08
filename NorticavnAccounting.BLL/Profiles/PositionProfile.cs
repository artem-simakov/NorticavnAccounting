using AutoMapper;
using NorticavnAccounting.Domain.Dto;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.BLL.Profiles;

/// <summary>
/// Profile for employee entity mappings.
/// </summary>
public class PositionProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the PositionProfile class.
    /// </summary>
    public PositionProfile()
    {
        CreateMap<Position, PositionDto>()
            .ReverseMap();
        CreateMap<Position, NewPositionDto>()
            .ReverseMap();
        CreateMap<PositionDto, NewPositionDto>()
            .ReverseMap();
    }
}