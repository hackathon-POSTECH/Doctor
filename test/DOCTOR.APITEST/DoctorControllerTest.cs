using DOCTOR.API.Controllers;
using DOCTOR.APPLICATION;
using DOCTOR.APPLICATION.Doctor.VerifyDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace DOCTOR.APITEST;

public class DoctorControllerTest
{

    private readonly IMediator _mediatorMock;

    public DoctorControllerTest()
    {
        _mediatorMock = Substitute.For<IMediator>();
    }


    [Fact]
    public async Task Should_Verify_Doctor_When_Not_Found()
    {
        var mockResult = ResultPattern<VerifyDoctorResponse>.ToError();
        var doctorId = Guid.NewGuid();
        var command = new VerifyDoctorQuery(doctorId);
        _mediatorMock.Send(command, Arg.Any<CancellationToken>())
                 .Returns(mockResult);

        var controller = new DoctorController(_mediatorMock);

        var result = await controller.VerifyDoctor(doctorId);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Should_Verify_Doctor_When_Ok()
    {
        var mockResult = ResultPattern<VerifyDoctorResponse>.ToSuccess(new VerifyDoctorResponse());
        var doctorId = Guid.NewGuid();
        var command = new VerifyDoctorQuery(doctorId);
        _mediatorMock.Send(command, Arg.Any<CancellationToken>())
                 .Returns(mockResult);

        var controller = new DoctorController(_mediatorMock);

        var result = await controller.VerifyDoctor(doctorId);

        Assert.IsType<OkObjectResult>(result);
    }
}