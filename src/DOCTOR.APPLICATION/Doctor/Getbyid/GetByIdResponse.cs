namespace DOCTOR.APPLICATION.Doctor.Getbyid;

public class GetByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public static GetByIdResponse ToResponse(DOMAIN.Doctor doctor)
        => new GetByIdResponse
        {
            Email = doctor.Email,
            Id = doctor.Id,
            Name = doctor.Name,
            Phone = "123"
        };

}
