﻿using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;

namespace _3_Fintranet.Application.Features.Doctors.Managers;

public interface IDoctorManager
{
    Task<ResponseDoctorDto?> GetAllAsync(RequestDoctorDto dto);
    Task<DoctorDto> GetByIdAsync(int? id, bool trucking = true);
    Task<DoctorDto> GetByEmailAsync(string? email, bool trucking = true);
    Task<bool> ExistsAsync(string email);
    Task<DoctorDto> CreateAsync(Doctor doctor);
    Task<DoctorDto> UpdateAsync(Doctor doctor);
    Task DeleteAsync(int doctorId);
}