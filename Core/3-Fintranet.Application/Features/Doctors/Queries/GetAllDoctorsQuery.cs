using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Services;
using AutoMapper;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Queries
{
    public record GetAllDoctorsQuery(RequestDoctorDto Dto) : IRequest<ResponseDoctorDto>
    {
        public class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorsQuery, ResponseDoctorDto>
        {
            private readonly IDoctorManager _doctorManager;
            private readonly IMapper _mapper;

            public GetAllDoctorQueryHandler(IDoctorManager doctorManager, IMapper mapper)
            {
                _doctorManager = doctorManager;
                _mapper = mapper;
            }

            public async Task<ResponseDoctorDto> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
            {
                var selectedDoctors = await _doctorManager.GetAllAsync(request.Dto);
                var doctors = selectedDoctors?.DoctorDtos;

                if (doctors == null) return new ResponseDoctorDto();

                var doctorsList = doctors.Select(d => _mapper.Map<DoctorDto>(d)).ToList();

                //new DoctorDto<int>
                //{
                //    Id = d.Id,
                //    DoctorGuid = d.DoctorGuid,
                //    BusinessMobileNumber = d.BusinessMobileNumber,
                //    Email = d.Email,
                //    FirstName = d.FirstName,
                //    LastName = d.LastName,
                //    MedicalHistory = d.MedicalHistory,
                //    MedicalSystemNumber = d.MedicalSystemNumber,
                //    PersonalMobileNumber = d.PersonalMobileNumber,
                //    PhoneNumber = d.PhoneNumber,
                //    TurningMethod = d.TurningMethod,
                //    Website = d.Website
                //}).ToList();

                var response = new ResponseDoctorDto
                {
                    DoctorDtos = doctorsList,
                    Rows = doctorsList.Count()
                };

                return response;
            }
        }
    }
}