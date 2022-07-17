using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
using AutoMapper;

namespace _6_Fintranet.Framework.AutoMapperConfigs
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto<Guid>>().ReverseMap();
        }
    }
}