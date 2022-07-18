using _3_Fintranet.Application.Features.Doctors.Dtos;

namespace _3_Fintranet.Application.Services
{
    public interface ICqrsDoctorService
    {
        Task<ResponseDoctorDto> GetAllDoctorsAsync(RequestDoctorDto requestDoctorDto);
        Task<DoctorDto> GetDoctorByIdAsync(int id);
    }
}
