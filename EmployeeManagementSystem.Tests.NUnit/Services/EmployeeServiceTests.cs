namespace EmployeeManagementSystem.Tests.Services;

[TestFixture]
public class EmployeeServiceTests
{
    private Mock<IUnitOfWork> _uowMock;
    private Mock<IGenericRepository<Employee>> _repoMock;
    private Mock<IMapper> _mapperMock;

    private EmpService _service;

    [SetUp]
    public void Setup()
    {
        _uowMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _repoMock = new Mock<IGenericRepository<Employee>>();

        _uowMock.Setup(x => x.Employees).Returns(_repoMock.Object);
        _service = new EmpService(_uowMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ShouldRetrunEmployee()
    {
        var employees = new List<Employee>
        {
            new Employee
            {
                Name = "vraj",
                EmailId="abc@test.com"
            }
        };
        var response = new List<ResponseDto>
        {
            new ResponseDto
            {
                Name = "vraj",
                EmailId="abc@test.com"
            }
        };
        _repoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);
        _mapperMock.Setup(x => x.Map<IEnumerable<ResponseDto>>(employees)).Returns(response);
        var result = await _service.GetAllAsync();
        Assert.That(result.Count(),Is.EqualTo(response.Count) );

        _repoMock.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnEmpty()
    {
        var employees = new List<Employee>();
        var response = new List<ResponseDto>();

        _repoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);
        _mapperMock.Setup(x => x.Map<IEnumerable<ResponseDto>>(employees));

        var result = await _service.GetAllAsync();
        Assert.That(result,Is.Empty);
    }

    [Test]
    public async Task GetByIdAsync_ShouldReturnEmployee()
    {
        var id = Guid.NewGuid();
        var employees = new Employee
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };

        var response = new ResponseDto
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };

        _repoMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(employees);

        _mapperMock.Setup(x => x.Map<ResponseDto>(employees)).Returns(response);

        var result = await _service.GetByIdAsync(id);

        Assert.That(result,Is.EqualTo(response));
    }

    [Test]
    public async Task GetByIdAsync_ShouldReturnNull_WhenEmployeeNotFound()
    {
        var id = Guid.NewGuid();
        _repoMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Employee?)null);
        _mapperMock.Setup(x => x.Map<ResponseDto>(null)).Returns((ResponseDto)null!);

        var result = await _service.GetByIdAsync(id);
        Assert.Null(result);
    }

    [Test]
    public async Task AddAsync_ShouldAddEmployee()
    {
        var dto = new CreateDto
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };
        var employees = new Employee
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };
        _mapperMock.Setup(x => x.Map<Employee>(dto)).Returns(employees);
        await _service.AddAsync(dto);
        _repoMock.Verify(x => x.AddAsync(employees), Times.Once);
    }

    [Test]
    public async Task AddAsync_ShouldCallSaveChanges()
    {
        var dto = new CreateDto
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };
        var employees = new Employee
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };
        _mapperMock.Setup(x => x.Map<Employee>(dto)).Returns(employees);
        await _service.AddAsync(dto);
        _uowMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_ShouldUpdate()
    {
        var dto = new UpdateDto
        {
            Id = Guid.NewGuid()
        };
        var employees = new Employee
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };
        _repoMock.Setup(x => x.GetByIdAsync(dto.Id)).ReturnsAsync(employees);
        await _service.UpdateAsync(dto);
        _mapperMock.Verify(x => x.Map(dto, employees), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_ShouldCallSaveChanges()
    {
        var dto = new UpdateDto
        {
            Id = Guid.NewGuid()
        };
        var employees = new Employee
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };

        _repoMock.Setup(x => x.GetByIdAsync(dto.Id)).ReturnsAsync(employees);

        await _service.UpdateAsync(dto);
        _uowMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_ShouldDeleteEmployee()
    {
        var id = Guid.NewGuid();
        var employee = new Employee
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };
        _repoMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(employee);
        await _service.DeleteAsync(id);
        _repoMock.Verify(x => x.Delete(employee), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_ShouldCallSaveChanges()
    {
        var id = Guid.NewGuid();
        var employee = new Employee
        {
            Name = "vraj",
            EmailId = "abc@test.com"
        };
        _repoMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(employee);
        await _service.DeleteAsync(id);
        _uowMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }
}
