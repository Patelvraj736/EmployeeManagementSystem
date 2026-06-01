namespace EmployeeManagementSystem.Application.Service;

public sealed class EmpService(IUnitOfWork uow, IMapper mapper) : IEmpService
{
    public async Task<IEnumerable<ResponseDto>> GetAllAsync()
    {
        var employees = await uow.Employees.GetAllAsync();
        return mapper.Map<IEnumerable<ResponseDto>>(employees);
    }

    public async Task<ResponseDto> GetByIdAsync(Guid id)
    {
        var employee = await uow.Employees.GetByIdAsync(id);
        return mapper.Map<ResponseDto>(employee);
    }
    public async Task AddAsync(CreateDto dto)
    {
        var employee = mapper.Map<Employee>(dto);

        if (employee == null)
            throw new Exception("Employee not found");

        employee.Joiningdate = DateTime.Now;

        employee.Status = true;

        await uow.Employees.AddAsync(employee);
        await uow.SaveChangesAsync();
    }
    public async Task UpdateAsync (UpdateDto dto)
    {
        var employee = await uow.Employees.GetByIdAsync(dto.Id);

        if (employee == null)
            throw new Exception("Employee not found");

        mapper.Map(dto, employee);
        await uow.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var employee = await uow.Employees.GetByIdAsync(id);

        if (employee == null)
            throw new Exception("Employee not found");

        uow.Employees.Delete(employee);

        await uow.SaveChangesAsync();
    }
}
