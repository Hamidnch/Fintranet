using _3_Fintranet.Application.Features.Doctors.Services;
using FluentValidation;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Commands
{
    public record DeleteDoctorCommand(int Id) : IRequest<Unit>
    {
        public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
        {
            public DeleteDoctorCommandValidator()
            {
                RuleFor(c => c.Id)
                    .NotEqual(0)
                    .WithMessage("The doctor id must not be empty");
            }
        }
        public record DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Unit>
        {
            private readonly IDoctorManager _doctorManager;

            public DeleteDoctorCommandHandler(IDoctorManager doctorManager)
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
