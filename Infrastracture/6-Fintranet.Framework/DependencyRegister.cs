using _3_Fintranet.Application.Features.Doctors.Services;
using _3_Fintranet.Application.Interfaces;
using _4_.Fintranet.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace _6_Fintranet.Framework
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddFintranetServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(typeof(GetAllDoctorsQuery).GetTypeInfo().Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            //services.AddFluentValidation(cfg =>
            //    cfg.RegisterValidatorsFromAssemblyContaining<CreateDoctorCommand>());
            //services.AddValidatorsFromAssembly(typeof(CreateDoctorCommand.CreateCustomerCommandValidator).Assembly);

            services.AddScoped<IFintranetContext>(provider => provider.GetService<FintranetContext>()!);
            services.AddDbContext<FintranetContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
            services.AddScoped(typeof(IFintranetRepository<>), typeof(FintranetRepository<>));
            services.AddScoped<IDoctorManager<Guid>, DoctorManager>();

            //services.AddIbanNet();
            //services.AddTransient<IValidator<Doctor>, DoctorValidator>();

            return services;
        }
    }
}