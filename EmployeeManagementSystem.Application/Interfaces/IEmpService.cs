namespace EmployeeManagementSystem.Application.Interfaces;

public interface IEmpService
{
    Task<IEnumerable<ResponseDto>> GetAllAsync();
    Task<ResponseDto> GetByIdAsync(Guid id);
    Task AddAsync(CreateDto dto);
    Task UpdateAsync(UpdateDto dto);
    Task DeleteAsync(Guid id);
}
