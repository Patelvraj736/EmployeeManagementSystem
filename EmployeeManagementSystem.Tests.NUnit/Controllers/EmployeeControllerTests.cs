namespace EmployeeManagementSystem.Tests.Controllers;

[TestFixture]
public class EmployeeControllerTests
{
    private Mock<IEmpService> _serviceMock;
    private EmployeeController _controller;

    [SetUp]
    public void Setup()
    {
        _serviceMock = new Mock<IEmpService>();
        _controller = new EmployeeController(_serviceMock.Object);
    }

    [Test]
    public async Task Create_ShouldReturnOk()
    {
        var dto = new CreateDto();
        var result = await _controller.Create(dto);
        var okResult = (OkObjectResult)result;
        Assert.That(okResult.Value, Is.EqualTo("Emp Created"));
        _serviceMock.Verify(x => x.AddAsync(dto), Times.Once);
    }

    [Test]
    public async Task Update_ShouldReturnOk()
    {
        var dto = new UpdateDto();
        var result = await _controller.Update(dto);
        var okResult = (OkObjectResult)result;
        Assert.That(okResult.Value, Is.EqualTo("Emp update"));
        _serviceMock.Verify(x => x.UpdateAsync(dto), Times.Once);
    }

    [Test]
    public async Task Delete_ShouldReturnOk()
    {
        var id = Guid.NewGuid();
        var result = await _controller.Delete(id);
        var okResult = (OkObjectResult)result;
        Assert.That(okResult.Value, Is.EqualTo("Emp Deactivate"));
    }

    [Test]
    public async Task Get_ShouldReturn_WhenIdProvided()
    {
        var id = Guid.NewGuid();
        var employee = new ResponseDto
        {
            Id = id
        };

        _serviceMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(employee);

        var result = await _controller.Get(id);
        var okResult = (OkObjectResult)result;
        Assert.That(okResult.Value, Is.EqualTo(employee));
        _serviceMock.Verify(x => x.GetByIdAsync(id), Times.Once);
    }

    [Test]
    public async Task Get_ShouldReturn_WhenIdNotProvided()
    {
        var employees = new List<ResponseDto>();
        _serviceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);
        var result = await _controller.Get(null);
        var okResult = (OkObjectResult)result;
        Assert.That(okResult.Value, Is.EqualTo(employees));
        _serviceMock.Verify(x => x.GetAllAsync(), Times.Once);
    }
}
