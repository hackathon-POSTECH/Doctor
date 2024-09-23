using MediatR;

namespace DOCTOR.APPLICATION.Doctor.VerifyDoctor;

public record VerifyDoctorQuery(Guid DoctorId) : IRequest<ResultPattern<VerifyDoctorResponse>>;
