namespace EmployeeManagementSystem.Tests.Controllers;

public class EmployeeControllerTests
{
    private readonly Mock<IEmpService> _serviceMock;
    private readonly EmployeeController _controller;
    public EmployeeControllerTests()
    {
        _serviceMock = new Mock<IEmpService>();
        _controller = new EmployeeController(_serviceMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnOk()
    {
        var dto = new CreateDto();
        var result = await _controller.Create(dto);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Emp Created", okResult.Value);
        _serviceMock.Verify(x => x.AddAsync(dto), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldReturnOk()
    {
        var dto = new UpdateDto();
        var result = await _controller.Update(dto);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Emp update", okResult.Value);
        _serviceMock.Verify(x => x.UpdateAsync(dto), Times.Once);
    }

    [Fact]
    public async Task Delete_ShouldReturnOk()
    {
        var id = Guid.NewGuid();
        var result = await _controller.Delete(id);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Emp Deactivate", okResult.Value);
    }

    [Fact]
    public async Task Get_ShouldReturn_WhenIdProvided()
    {
        var id = Guid.NewGuid();
        var employee = new ResponseDto
        {
            Id = id
        };

        _serviceMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(employee);

        var result = await _controller.Get(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(employee, okResult.Value);
        _serviceMock.Verify(x => x.GetByIdAsync(id), Times.Once);
    }

    [Fact]
    public async Task Get_ShouldReturn_WhenIdNotProvided()
    {
        var employees = new List<ResponseDto>();
        _serviceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);
        var result = await _controller.Get(null);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(employees, okResult.Value);
        _serviceMock.Verify(x => x.GetAllAsync(), Times.Once);
    }
}
