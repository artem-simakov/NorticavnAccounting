using System.Reflection;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MockQueryable.Moq;
using NorticavnAccounting.BLL.Profiles;
using NorticavnAccounting.BLL.Services;
using NorticavnAccounting.DAL.Contexts;
using NorticavnAccounting.Domain.Dto;
using NorticavnAccounting.Domain.Entities;

namespace NorticavnAccounting.Tests;

[TestClass]
public class EmployeeServiceTests
{
    #region Fields

    private Mock<NorticavnAccountingDbContext> _dbContext;

    private IMapper _mapper;
    private EmployeeService _employeeService;

    #endregion

    #region Test Initialize

    [TestInitialize]
    public void TestInitialize()
    {
        _dbContext = new Mock<NorticavnAccountingDbContext>();
        _mapper = InitializeMapper(typeof(EmployeeProfile).Assembly);

        _employeeService = new Mock<EmployeeService>(_mapper, _dbContext.Object).Object;
    }

    #endregion

    #region Methods

    [TestMethod]
    public async Task CreateEmployeeAsync_ShouldSaveEmployee_Test()
    {
        // Arrange
        var token = default(CancellationToken);
        var data = new List<Employee>().AsQueryable().BuildMockDbSet();

        NewEmployeeDto employeeDto = new NewEmployeeDto()
        {
            FirstName = "Jack",
            LastName = "Herer",
            FatherName = "Smith",
            PositionIds = new int[] { }
        };

        _dbContext.Setup(x => x.Employees.AddAsync(It.IsAny<Employee>(), token))
            .Callback<Employee, CancellationToken>((x, token) => data.Object.Add(x));

        // Act
        await _employeeService.CreateEmployeeAsync(employeeDto, token);

        // Assert
        _dbContext.Verify(m => m.SaveChangesAsync(token), Times.Once());
    }

    [TestMethod]
    public async Task GetEmployeeByIdAsync_ShouldReturnEmployee_Test()
    {
        // Arrange
        var token = default(CancellationToken);
        var data = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                FirstName = "Jack",
                LastName = "Herer",
                FatherName = "Smith"
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Jack",
                LastName = "Sparrow",
                FatherName = "Smith"
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Andrew",
                LastName = "Troelsen",
                FatherName = "Smith"
            }
        };

        var dbSet = data.AsQueryable().BuildMockDbSet();
        _dbContext.Setup(x => x.Employees).Returns(dbSet.Object);


        // Act  
        var result = await _employeeService.GetEmployeeByIdAsync(1, token);

        // Assert
        Assert.IsNotNull(result);

        Assert.AreEqual(expected: 1, actual: result.Id);
    }

    [TestMethod]
    public async Task GetEmployeesAsync_ShouldReturnEmployees_Test()
    {
        // Arrange
        var token = default(CancellationToken);
        var data = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                FirstName = "Jack",
                LastName = "Herer",
                FatherName = "Smith"
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Jack",
                LastName = "Sparrow",
                FatherName = "Smith"
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Andrew",
                LastName = "Troelsen",
                FatherName = "Smith"
            }
        };

        var dbSet = data.AsQueryable().BuildMockDbSet();
        _dbContext.Setup(x => x.Employees).Returns(dbSet.Object);

        // Act  
        var result = await _employeeService.GetEmployeesAsync(token);

        // Assert
        Assert.IsNotNull(result);

        Assert.AreEqual(expected: 3, actual: result.Count());
    }

    public IMapper InitializeMapper(Assembly assembly)
    {
        var configurationProvider = new MapperConfiguration(cfg => cfg.AddMaps(assembly));
        return configurationProvider.CreateMapper();
    }

    #endregion
}