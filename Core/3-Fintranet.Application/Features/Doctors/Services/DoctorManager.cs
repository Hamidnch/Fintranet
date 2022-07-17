using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;

namespace _3_Fintranet.Application.Features.Doctors.Services
{
    public class DoctorManager : IDoctorManager
    {
        public async Task<ResponseDoctorDto> GetAllAsync(RequestDoctorDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<DoctorDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<DoctorDto> CreateAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public async Task<DoctorDto> UpdateAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
