namespace _3_Fintranet.Application.Features.Doctors.Dtos
{
    public class ResponseDoctorDto
    {
        public IReadOnlyList<DoctorDto<Guid>> DoctorDtos { get; init; }
        public int Rows { get; set; }
    }
}
