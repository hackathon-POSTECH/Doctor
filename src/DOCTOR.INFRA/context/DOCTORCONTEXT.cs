using DOCTOR.DOMAIN;
using Microsoft.EntityFrameworkCore;

namespace DOCTOR.INFRA.context;

public class DOCTORCONTEXT : DbContext
{
    public DOCTORCONTEXT(DbContextOptions<DOCTORCONTEXT> options) : base(options)
    {

    }

    public DbSet<Doctor> Doctors { get; set; }
}
