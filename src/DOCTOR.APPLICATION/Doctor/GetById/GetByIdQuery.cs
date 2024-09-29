using DOCTOR.APPLICATION.Doctor.GetById;
using MediatR;

namespace DOCTOR.APPLICATION.Doctor.Getbyid;

public record GetByIdQuery(Guid id) : IRequest<GetByIdResponse>;