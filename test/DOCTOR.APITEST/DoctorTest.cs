using DOCTOR.DOMAIN;

namespace DOCTOR.APITEST;

public class DoctorTest
{
    [Fact]
    public void CreateDoctor_ShouldThrowException_WhenCpfIsInvalid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var name = "Dr. Smith";
        var crm = "123456";
        var invalidCpf = "999.999.999-99";
        var email = "dr.smith@example.com";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            Doctor.CreateDoctor(userId, name, crm, invalidCpf, email));

        Assert.Equal("CPF inválido.", exception.Message);
    }

    [Fact]
    public void CreateDoctor_ShouldInitializePropertiesCorrectly_WhenCpfIsValid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var name = "Dr. Jones";
        var crm = "654321";
        var validCpf = "123.456.789-09";
        var email = "dr.jones@example.com";

        // Act
        var doctor = Doctor.CreateDoctor(userId, name, crm, validCpf, email);

        // Assert
        Assert.Equal(userId, doctor.UserId);
        Assert.Equal(name, doctor.Name);
        Assert.Equal(crm, doctor.Crm);
        Assert.Equal(validCpf, doctor.Cpf);
        Assert.Equal(email, doctor.Email);
        Assert.Equal(9, doctor.WorkStartTime);
        Assert.Equal(9, doctor.WorkEndTime);
    }
}