using FluentValidation;
using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.Application.Validator;

public class UpdateValidator :AbstractValidator<UpdateDto>
{
    public UpdateValidator()
    {

        RuleFor(x => x.Name).NotEmpty().WithMessage("Enter Name");

        RuleFor(x => x.EmailId).NotEmpty().EmailAddress().WithMessage("Enter valid email");

        RuleFor(x => x.Salary).GreaterThan(0).WithMessage("Enter valid salary");
    }
}
