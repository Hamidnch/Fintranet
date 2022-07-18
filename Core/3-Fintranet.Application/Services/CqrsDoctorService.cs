using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Queries;
using MediatR;

namespace _3_Fintranet.Application.Services
{
    public class CqrsDoctorService : ICqrsDoctorService
    {
        private readonly IMediator _mediator;

        public CqrsDoctorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResponseDoctorDto> GetAllDoctorsAsync(RequestDoctorDto requestDoctorDto)
        {
            return await _mediator.Send(new GetAllDoctorsQuery(requestDoctorDto));
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            return await _mediator.Send(new GetDoctorByIdQuery(Id: id));
        }
    }
}
