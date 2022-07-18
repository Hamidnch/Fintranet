namespace _3_Fintranet.Application.Features.Doctors.Dtos
{
    public class ResponseDoctorDto
    {
        public IReadOnlyList<DoctorDto> DoctorDtos { get; init; }
        public int Rows { get; set; }
    }
}
