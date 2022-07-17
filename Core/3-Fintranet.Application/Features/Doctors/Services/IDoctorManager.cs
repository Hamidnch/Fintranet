using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
namespace _3_Fintranet.Application.Features.Doctors.Services;

public interface IDoctorManager<TKey> where TKey : struct
{
    Task<ResponseDoctorDto?> GetAllAsync(RequestDoctorDto dto);
    Task<DoctorDto<TKey>> GetByIdAsync(Guid id);
    Task<DoctorDto<TKey>> CreateAsync(Doctor doctor);
    Task<DoctorDto<TKey>> UpdateAsync(Doctor doctor);
    Task DeleteAsync(Guid doctorId);
}