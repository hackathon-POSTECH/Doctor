using MediatR;

namespace DOCTOR.APPLICATION.Doctor.GetAllDoctors;

public record GetAllDoctorsQuery() : IRequest<IEnumerable<GetAllDoctorsResponse>>;
