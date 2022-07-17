using _3_Fintranet.Application.Features.Doctors.Services;
using FluentValidation;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Commands
{
    public record DeleteDoctorCommand(Guid Id) : IRequest<Unit>
    {
        public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
        {
            public DeleteDoctorCommandValidator()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("The doctor id must not be empty");
            }
        }
        public record DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Unit>
        {
            private readonly IDoctorManager<Guid> _doctorManager;

            public DeleteDoctorCommandHandler(IDoctorManager<Guid> doctorManager)
            {
                _doctorManager = doctorManager;
            }

            public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
            {
                await _doctorManager.DeleteAsync(request.Id);
                return Unit.Value;

                //DoctorDto doctorDto = await _doctorManager.GetByIdAsync(request.Id);
                //await _doctorManager.DeleteAsync(doctorDto);
            }
        }
    }
}
