using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Managers;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Queries
{
    public record GetDoctorByEmailQuery(string? Email) : IRequest<DoctorDto>
    {
        public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByEmailQuery, DoctorDto>
        {
            private readonly IDoctorManager _doctorManager;

            public GetDoctorByIdQueryHandler(IDoctorManager doctorManager)
            {
                _doctorManager = doctorManager;
            }

            public async Task<DoctorDto> Handle(GetDoctorByEmailQuery query, CancellationToken cancellationToken)
            {
                if (query.Email != null)
                    return await _doctorManager.GetByEmailAsync(query.Email);

                return new DoctorDto();
            }
        }
    }
}