using DOCTOR.APPLICATION.Doctor.GetAllDoctors;
using DOCTOR.APPLICATION.Doctor.VerifyDoctor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DOCTOR.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllAsync()
    {
        var query = new GetAllDoctorsQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpHead("verifydoctor/{doctorId}")]
    public async Task<IActionResult> VerifyDoctor([FromRoute] Guid doctorId)
    {
        var query = new VerifyDoctorQuery(doctorId);
        var result = await _mediator.Send(query);
        if (result.Success) return Ok(result);
        return NotFound();
    }
}
