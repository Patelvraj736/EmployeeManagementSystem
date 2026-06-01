using AutoMapper;
using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Application.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Employee, ResponseDto>()
            .ForMember(dest => dest.Department,opt => opt.MapFrom(src => src.DepartmentId.ToString()));
        CreateMap<CreateDto, Employee>();
        CreateMap<UpdateDto, Employee>()
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Joiningdate, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
