using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Application.Mapping;
using EmployeeManagementSystem.Application.Service;
using EmployeeManagementSystem.Application.Validator;
using EmployeeManagementSystem.Infrastructure.Data;
using EmployeeManagementSystem.Infrastructure.Repository;

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<IEmpService, EmpService>();

        builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);

        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddValidatorsFromAssemblyContaining<CreateValidator>();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();