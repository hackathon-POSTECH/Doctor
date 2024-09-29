using DOCTOR.APPLICATION.Doctor.GetById;
using DOCTOR.INFRA.Repositories;
using MediatR;

namespace DOCTOR.APPLICATION.Doctor.Getbyid;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdResponse>
{
    private readonly IDoctorRepository _repository;

    public GetByIdQueryHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return GetByIdResponse.ToResponse(await _repository.GetByIdAsync(request.id));
    }
}
