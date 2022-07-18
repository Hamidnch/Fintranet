using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Fintranet.Application.Features.Doctors.Services
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IMapper _mapper;
        private readonly IFintranetRepository<Doctor> _doctorRepository;

        public DoctorManager(IFintranetRepository<Doctor> doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDoctorDto?> GetAllAsync(RequestDoctorDto dto)
        {
            var doctorRepositories = _doctorRepository.Table;

            if (!string.IsNullOrWhiteSpace(dto.SearchText))
            {
                doctorRepositories = doctorRepositories?.Where(d =>
                    (d.FirstName != null && (d.FirstName.Contains(dto.SearchText)) ||
                     (d.LastName != null && d.LastName.Contains(dto.SearchText)) ||
                     (d.Email != null && d.Email.Contains(dto.SearchText))));
            }

            if (doctorRepositories == null) return default;

            var doctorList = await doctorRepositories
                .Select(doctor => _mapper.Map<Doctor, DoctorDto>(doctor))
                //.Select(p => new DoctorDto<int>
                //{
                //    Id = p.Id,
                //    FirstName = p.FirstName,
                //    LastName = p.LastName,
                //    Email = p.Email,
                //    PhoneNumber = p.PhoneNumber,
                //    MedicalSystemNumber = p.MedicalSystemNumber,
                //    BusinessMobileNumber = p.BusinessMobileNumber,
                //    Doctorint = p.Doctorint,
                //    MedicalHistory = p.MedicalHistory,
                //    PersonalMobileNumber = p.PersonalMobileNumber,
                //    TurningMethod = p.TurningMethod,
                //    Website = p.Website

                //})
                .OrderBy(p => p.LastName)
                .ThenBy(v => v.Id)
                .ToListAsync();

            var response = new ResponseDoctorDto
            {
                DoctorDtos = doctorList,
                Rows = doctorList.Count
            };
            return response;

        }

        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            return _mapper.Map<DoctorDto>(await _doctorRepository.Table.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<DoctorDto> CreateAsync(Doctor doctor)
        {
            await _doctorRepository.InsertAsync(doctor);

            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<DoctorDto> UpdateAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task DeleteAsync(int doctorId)
        {
            var doctor = (await _doctorRepository.GetByIdAsync(doctorId))!;
            await _doctorRepository.DeleteAsync(doctor);
        }
    }
}