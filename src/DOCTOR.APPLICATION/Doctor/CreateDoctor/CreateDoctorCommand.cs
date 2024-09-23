using DOCTOR.APPLICATION.Doctor.CreateDoctor;
using MediatR;

namespace DOCTOR.APPLICATION.doctor.CreateDoctor;

public record CreateDoctorCommand(
    Guid UserId,
    string Crm,
    string Cpf,
    string Name,
    string Email
    ) : IRequest<CreateDoctorResponse>;


