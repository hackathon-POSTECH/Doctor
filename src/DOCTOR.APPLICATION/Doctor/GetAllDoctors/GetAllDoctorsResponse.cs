namespace DOCTOR.APPLICATION.Doctor.GetAllDoctors;

public class GetAllDoctorsResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Crm { get; set; }
    public string Cpf { get; set; }
    public int WorkStartTime { get; set; }
    public int WorkEndTime { get; set; }
    public static IEnumerable<GetAllDoctorsResponse> ToResponse(IEnumerable<DOCTOR.DOMAIN.Doctor> doctors)
        => doctors.Select(x => new GetAllDoctorsResponse
        {
            Id = x.Id,
            UserId = x.UserId,
            Name = x.Name,
            Email = x.Email,
            Crm = x.Crm,
            Cpf = x.Cpf,
            WorkStartTime = x.WorkStartTime,
            WorkEndTime = x.WorkEndTime,
        });
}
