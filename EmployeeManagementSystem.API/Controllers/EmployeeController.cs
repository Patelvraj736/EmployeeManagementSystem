using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Application.Interfaces;

namespace EmployeeManagementSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmpService empService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateDto dto)
    {
        await empService.AddAsync(dto);
        return Ok("Emp Created");
    }
    [HttpPatch]
    public async Task<IActionResult> Update(UpdateDto dto)
    {
        await empService.UpdateAsync(dto);
        return Ok("Emp update");
    }
    [HttpDelete ("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await empService.DeleteAsync(id);
        return Ok("Emp Deactivate");
    }
    [HttpGet]
    public async Task<IActionResult> Get(Guid? id)
    {
        if (id.HasValue)
            return Ok(await  empService.GetByIdAsync(id.Value));

        return Ok(await empService.GetAllAsync());
    }
}
