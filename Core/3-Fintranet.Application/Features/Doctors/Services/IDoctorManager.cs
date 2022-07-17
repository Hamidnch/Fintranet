using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
namespace _3_Fintranet.Application.Features.Doctors.Services;

public interface IDoctorManager
{
    Task<ResponseDoctorDto> GetAllAsync(RequestDoctorDto dto);
    Task<DoctorDto> GetByIdAsync(Guid id);
    Task<DoctorDto> CreateAsync(Doctor doctor);
    Task<DoctorDto> UpdateAsync(Doctor doctor);
    Task DeleteAsync(Guid doctorId);
}