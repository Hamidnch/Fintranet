namespace _3_Fintranet.Application.Features.Doctors.Dtos
{
    public class RequestDoctorDto
    {
        public string? SearchText { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}