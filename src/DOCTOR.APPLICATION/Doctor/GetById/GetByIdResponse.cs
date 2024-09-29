using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOCTOR.APPLICATION.Doctor.GetById;

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

