using _1_Fintranet.Common.Constants;
using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Behaviors;
using _3_Fintranet.Application.Features.Doctors.Commands;
using _3_Fintranet.Application.Features.Doctors.Managers;
using _3_Fintranet.Application.Features.Doctors.Queries;
using _3_Fintranet.Application.Interfaces;
using _4_.Fintranet.Persistence.Contexts;
using _6_Fintranet.Framework.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using _3_Fintranet.Application.Services;

namespace _6_Fintranet.Framework.Ioc
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddFintranetServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetAllDoctorsQuery).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.AddFluentValidation(cfg =>
                cfg.RegisterValidatorsFromAssemblyContaining<CreateDoctorCommand>());
            services.AddValidatorsFromAssembly(typeof(CreateDoctorCommand.CreateDoctorCommandValidator).Assembly);

            services.AddScoped<IFintranetContext>(provider => provider.GetService<FintranetContext>()!);
            services.AddDbContext<FintranetContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(DefaultConstants.DefaultConnectionString)));
            services.AddScoped(typeof(IFintranetRepository<>), typeof(FintranetRepository<>));

            services.AddScoped<IDoctorManager, DoctorManager>();
            services.AddScoped<ICqrsDoctorService, CqrsDoctorService>();

            services.AddTransient<IValidator<Doctor>, DoctorValidator>();

            return services;
        }
    }
}