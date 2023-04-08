using AutoMapper;
using NorticavnAccounting.Domain.Dto;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.BLL.Profiles;

/// <summary>
/// Profile for employee entity mappings.
/// </summary>
public class EmployeeProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the EmployeeProfile class.
    /// </summary>
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ReverseMap();
        CreateMap<Employee, NewEmployeeDto>()
            .ReverseMap();
        CreateMap<EmployeeDto, NewEmployeeDto>()
            .ReverseMap();
    }
}