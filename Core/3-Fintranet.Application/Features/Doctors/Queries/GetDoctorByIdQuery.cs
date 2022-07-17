using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Services;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Queries
{
    public record GetDoctorByIdQuery(Guid Id) : IRequest<DoctorDto<Guid>>
    {
        public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto<Guid>>
        {
            private readonly IDoctorManager<Guid> _doctorManager;

            public GetDoctorByIdQueryHandler(IDoctorManager<Guid> doctorManager)
            {
                _doctorManager = doctorManager;
            }

            public async Task<DoctorDto<Guid>> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
            {
                return await _doctorManager.GetByIdAsync(query.Id);
            }
        }
    }
}