using System;
using DOCTOR.DOMAIN.common;
using DOCTOR.DOMAIN.Extensions;

namespace DOCTOR.DOMAIN
{
    public class Doctor : AggregateRoot
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Crm { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public int WorkStartTime { get; set; }
        public int WorkEndTime { get; set; }

        public static Doctor CreateDoctor(Guid userId, string name, string crm, string cpf, string email)
        {
            if (!CPF.IsValid(cpf))
                throw new ArgumentException("CPF inválido.");

            return new Doctor()
            {
                Cpf = cpf,
                Crm = crm,
                Email = email,
                UserId = userId,
                Name = name,
                WorkStartTime = 9,
                WorkEndTime = 9,
            };
        }
    }
}