using _1_Fintranet.Common.Constants;
using _1_Fintranet.Common.Enums;
using _2_Fintranet.Domain.Commons;
using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Commands;
using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Queries;
using _3_Fintranet.Application.Features.Doctors.Services;
using _3_Fintranet.Application.Interfaces;
using _4_.Fintranet.Persistence.Contexts;
using _6_Fintranet.Framework.MapperConfigs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;

namespace Fintranet.Test.Validation
{
    public class CqrsDoctorTest
    {
        private readonly IDoctorManager _doctorManager;
        private readonly IMapper _mapper;
        public CqrsDoctorTest()
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DoctorProfile());
            });
            _mapper = mockMapper.CreateMapper();
            var repository = GetFintranetRepository<Doctor>();
            _doctorManager = new DoctorManager(repository, _mapper);
        }

        private static FintranetContext CreateDbContext()
        {
            var basePath = Directory.GetCurrentDirectory();
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath: basePath)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString =
                configBuilder.GetConnectionString(DefaultConstants.DefaultConnectionString);
            var builder = new DbContextOptionsBuilder<FintranetContext>();
            builder.UseSqlServer(connectionString);
            return new FintranetContext(builder.Options);
        }
        private static IFintranetRepository<T> GetFintranetRepository<T>() where T : BaseEntity
        {
            var context = CreateDbContext();
            IFintranetRepository<T> fintranetRepository = new FintranetRepository<T>(context);
            return fintranetRepository;
        }


        [Fact]
        public async Task Load_All_Doctors_Test()
        {
            var handler = new GetAllDoctorsQuery.GetAllDoctorQueryHandler(_doctorManager, _mapper);
            var result =
                handler.Handle(new GetAllDoctorsQuery(new RequestDoctorDto()), CancellationToken.None);

            await result.ShouldBeOfType<Task<ResponseDoctorDto>>();

            result.Result.Rows.ShouldBe(3);
        }
        [Fact]
        public async Task Filter_Doctors_By_Email_Test()
        {
            var handler = new GetDoctorByEmailQuery.GetDoctorByIdQueryHandler(_doctorManager);
            var result = await handler.Handle(new GetDoctorByEmailQuery("hamidnch2007@gmail.com"), CancellationToken.None);

            result.ShouldBeOfType<DoctorDto>();
            result.DoctorGuid.ShouldBe(Guid.Parse("46ba4525-2a27-45b4-9b4e-b0e30f37e2f0"));
        }

        [Fact]
        public async Task Create_Doctor_Test()
        {
            var doctor = new Doctor(
                "Hasan", "Mohammadi", GenderType.Male, 2, "26596365624",
                "hasanmohammadi@yahoo.com", "32326363",
                "09145623625", null, null,
                TurningMethod.InPerson, 25, null);
            
            var doctorDto = _mapper.Map<Doctor, DoctorDto>(doctor);

            var createDoctorCommand = new CreateDoctorCommand(doctorDto);
            var mediator = new Mock<IMediator>();
            var handler = new CreateDoctorCommand.CreateDoctorCommandCommandHandler(_mapper, mediator.Object, _doctorManager);
            var result = await handler.Handle(createDoctorCommand, CancellationToken.None);
            
            result.ShouldBeOfType<DoctorDto?>();
            result.MedicalSystemNumber.ShouldBe("32326363");
        }

        [Theory]
        [InlineData(8)]
        public async Task Update_Doctor_Test(int doctorId)
        {
            var doctorDto = await _doctorManager.GetByIdAsync(doctorId);
            
            doctorDto.FirstName = "Nima";
            doctorDto.LastName = "Shademan";
            doctorDto.Email = "NimaShademan@gmail.com";
            doctorDto.MedicalSystemNumber = "123456";
            doctorDto.FullName = $"{doctorDto.FirstName} {doctorDto.LastName}";
            doctorDto.BusinessMobileNumber = "09191686710";
            doctorDto.NationalCode = "47253325110";
            doctorDto.TurningMethod = TurningMethod.ByPhone;
            doctorDto.PersonalMobileNumber = "09117781206";
            doctorDto.PhoneNumber = "0213615682";
            var updateDoctorCommand = new UpdateDoctorCommand(doctorDto);
            var handler = new UpdateDoctorCommand.UpdateDoctorCommandHandler(_doctorManager, _mapper);
            var result = await handler.Handle(updateDoctorCommand, CancellationToken.None);

            result.FirstName.ShouldBe("Nima");
        }

        [Theory]
        [InlineData(7)]
        public async Task Delete_Doctor_Test(int doctorId)
        {
            var deleteDoctorCommand = new DeleteDoctorCommand(doctorId);
            var handler = new DeleteDoctorCommand.DeleteDoctorCommandHandler(_doctorManager);
            await handler.Handle(deleteDoctorCommand, CancellationToken.None);

            var doctorDto = await _doctorManager.GetByIdAsync(doctorId);

            Assert.Null(doctorDto);
        }
    }
}