using DOCTOR.INFRA.Repositories;
using MediatR;

namespace DOCTOR.APPLICATION.Doctor.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<GetAllDoctorsResponse>>
{
    private readonly IDoctorRepository _doctorRespository;
    public GetAllDoctorsQueryHandler(IDoctorRepository doctorRespository)
    {
        _doctorRespository = doctorRespository;
    }

    public async Task<IEnumerable<GetAllDoctorsResponse>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _doctorRespository.GetAllAsync(x => x.UserId != Guid.Empty);
        return GetAllDoctorsResponse.ToResponse(doctors);
    }
}
