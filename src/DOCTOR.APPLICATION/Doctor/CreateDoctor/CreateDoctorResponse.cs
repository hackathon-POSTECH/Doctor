namespace DOCTOR.APPLICATION.Doctor.CreateDoctor;

public class CreateDoctorResponse
{
    public static CreateDoctorResponse ToResponse(DOCTOR.DOMAIN.Doctor doctor)
        => new CreateDoctorResponse();
}
