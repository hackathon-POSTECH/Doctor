using DOCTOR.INFRA.Repositories;
using MediatR;

namespace DOCTOR.APPLICATION.Doctor.VerifyDoctor;

public class VerifyDoctorQueryHandler : IRequestHandler<VerifyDoctorQuery, ResultPattern<VerifyDoctorResponse>>
{
    private readonly IDoctorRepository _repository;

    public VerifyDoctorQueryHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultPattern<VerifyDoctorResponse>> Handle(VerifyDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.DoctorId);
        if (doctor == null)
        {
            return ResultPattern<VerifyDoctorResponse>.ToError();
        }
       return ResultPattern<VerifyDoctorResponse>.ToSuccess(VerifyDoctorResponse.ToResponse());  
    }
}
