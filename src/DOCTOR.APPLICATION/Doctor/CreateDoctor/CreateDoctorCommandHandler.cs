using DOCTOR.APPLICATION.Doctor.CreateDoctor;
using DOCTOR.INFRA.Repositories;
using MediatR;
using DOCTOR.DOMAIN;

namespace DOCTOR.APPLICATION.doctor.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>
{
    private readonly IDoctorRepository _doctorRepository;
    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = DOCTOR.DOMAIN.Doctor.CreateDoctor(request.UserId, request.Name, request.Crm, request.Cpf, request.Email);

        await _doctorRepository.AddAsync(doctor);
        _doctorRepository.SaveChangesAsync();

        return CreateDoctorResponse.ToResponse(doctor);
    }
}
