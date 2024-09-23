using DOCTOR.DOMAIN.common;

namespace DOCTOR.DOMAIN;

public class Doctor : AggregateRoot
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public string Crm { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }

    public static Doctor CreateDoctor(Guid userId, string Name, string Crm, string Cpf, string Email)
    {
        return new Doctor()
        {
            Cpf = Cpf,
            Crm = Crm,
            Email = Email,
            UserId = userId,
            Name = Name,    
        };
    }
}
