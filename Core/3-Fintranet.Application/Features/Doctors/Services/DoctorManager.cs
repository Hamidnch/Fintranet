using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using AutoMapper.QueryableExtensions;

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

            var doctorList = doctorRepositories
                .OrderBy(p => p.LastName)
                .ThenBy(v => v.Id)
                .Select(doctor => _mapper.Map<Doctor, DoctorDto>(doctor))
                .ToList();

            var response = new ResponseDoctorDto
            {
                DoctorDtos = doctorList,
                Rows = doctorList.Count
            };
            return response;

        }

        public async Task<DoctorDto> GetByIdAsync(int? id, bool trucking = true)
        {
            if (id == null) return new DoctorDto();
            return trucking ? _mapper.Map<DoctorDto>(await _doctorRepository.Table.FirstOrDefaultAsync(x => x.Id == id)) 
                : _mapper.Map<DoctorDto>(_doctorRepository.Get.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<DoctorDto> GetByEmailAsync(string? email, bool trucking = true)
        {
            var allDoctors = trucking ? _doctorRepository.Table : _doctorRepository.Get;
   
                var doctor = await allDoctors.FirstOrDefaultAsync(d => d.Email != null && d.Email == email);
                return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _doctorRepository.Table.AnyAsync(d => d.Email != null && d.Email.ToLower() == email.ToLower());
        }

        public async Task<DoctorDto> CreateAsync(Doctor doctor)
        {
            if (doctor.Email != null && await ExistsAsync(doctor.Email))
            {
                throw new DbUpdateException("The doctor with this email is exists.");
            }
            else
            {
                await _doctorRepository.InsertAsync(doctor);
            }

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