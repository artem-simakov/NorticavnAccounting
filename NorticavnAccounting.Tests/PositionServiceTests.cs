using System.Reflection;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;
using NorticavnAccounting.BLL.Profiles;
using NorticavnAccounting.BLL.Services;
using NorticavnAccounting.DAL.Contexts;
using NorticavnAccounting.Domain.Dto;
using NorticavnAccounting.Domain.Entities;
using NorticavnAccounting.Domain.Enum;

namespace NorticavnAccounting.Tests;

[TestClass]
public class PositionServiceTests
{
    #region Fields

    private Mock<NorticavnAccountingDbContext> _dbContext;

    private IMapper _mapper;
    private PositionService _positionService;

    #endregion

    #region Test Initialize

    [TestInitialize]
    public void TestInitialize()
    {
        _dbContext = new Mock<NorticavnAccountingDbContext>();
        _mapper = InitializeMapper(typeof(PositionProfile).Assembly);

        _positionService = new Mock<PositionService>(_mapper, _dbContext.Object).Object;
    }

    #endregion

    #region Methods

    [TestMethod]
    public async Task CreatePositionAsync_ShouldSavePosition_Test()
    {
        // Arrange
        var token = default(CancellationToken);
        var data = new List<Position>().AsQueryable().BuildMockDbSet();

        NewPositionDto newPositionDto = new NewPositionDto()
        {
            JobTitle = "Best Work In World",
            Grade = Grade.SixthGrade
        };

        _dbContext.Setup(x => x.Positions.AddAsync(It.IsAny<Position>(), token))
            .Callback<Position, CancellationToken>((x, token) => data.Object.Add(x));

        // Act
        await _positionService.CreatePositionAsync(newPositionDto, token);

        // Assert
        _dbContext.Verify(m => m.SaveChangesAsync(token), Times.Once());
    }

    [TestMethod]
    public async Task GetPositionByIdAsync_ShouldReturnPosition_Test()
    {
        // Arrange
        var token = default(CancellationToken);
        var data = new List<Position>()
        {
            new Position()
            {
                Id = 1,
                JobTitle = "Actress",
                Grade = Grade.EighthGrade
            },
            new Position()
            {
                Id = 2,
                JobTitle = "Cameraman",
                Grade = Grade.EighthGrade
            },
            new Position()
            {
                Id = 3,
                JobTitle = "Actor",
                Grade = Grade.EighthGrade
            }
        };

        var dbSet = data.AsQueryable().BuildMockDbSet();
        _dbContext.Setup(x => x.Positions).Returns(dbSet.Object);


        // Act  
        var result = await _positionService.GetPositionByIdAsync(1, token);

        // Assert
        Assert.IsNotNull(result);

        Assert.AreEqual(expected: 1, actual: result.Id);
    }

    [TestMethod]
    public async Task GetEmployeesAsync_ShouldReturnEmployees_Test()
    {
        // Arrange
        var token = default(CancellationToken);
        var data = new List<Position>()
        {
            new Position()
            {
                Id = 1,
                JobTitle = "Title",
                Grade = Grade.EighthGrade
            },
            new Position()
            {
                Id = 2,
                JobTitle = "Title",
                Grade = Grade.EighthGrade
            },
            new Position()
            {
                Id = 3,
                JobTitle = "Title",
                Grade = Grade.EighthGrade
            }
        };

        var dbSet = data.AsQueryable().BuildMockDbSet();
        _dbContext.Setup(x => x.Positions).Returns(dbSet.Object);

        // Act  
        var result = await _positionService.GetPositionsAsync(token);

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