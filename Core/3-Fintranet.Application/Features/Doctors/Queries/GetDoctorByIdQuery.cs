using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Managers;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Queries
{
    public record GetDoctorByIdQuery(int? Id) : IRequest<DoctorDto>
    {
        public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto>
        {
            private readonly IDoctorManager _doctorManager;

            public GetDoctorByIdQueryHandler(IDoctorManager doctorManager)
            {
                _doctorManager = doctorManager;
            }

            public async Task<DoctorDto> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
            {
                if (query.Id != null)
                    return await _doctorManager.GetByIdAsync(query.Id);

                return new DoctorDto();
            }
        }
    }
}
