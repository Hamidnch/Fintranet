using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Services;
using _6_Fintranet.Framework.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _7_Fintranet.Mvc.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ICqrsDoctorService _cqrsDoctorService;
        private readonly IMapper _mapper;
        public DoctorController(ICqrsDoctorService cqrsDoctorService, IMapper mapper)
        {
            _cqrsDoctorService = cqrsDoctorService;
            _mapper = mapper;
        }
        public async Task<IActionResult> List()
        {
            var responseDoctorDto = await _cqrsDoctorService.GetAllDoctorsAsync(new RequestDoctorDto());
            var model = 
                responseDoctorDto.DoctorDtos.Select(t => _mapper.Map<DoctorDto, DoctorModel>(t));
            return View(model);
        }
    }
}
