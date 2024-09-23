using DOCTOR.DOMAIN;
using DOCTOR.INFRA.context;
using DOCTOR.INFRA.Repositories.Common;

namespace DOCTOR.INFRA.Repositories;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    public DoctorRepository(DOCTORCONTEXT context) : base(context)
    {
    }
}
