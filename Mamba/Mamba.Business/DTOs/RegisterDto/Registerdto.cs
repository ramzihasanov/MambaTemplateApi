using FluentValidation;
using Mamba.DTOs.WorkerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Business.DTOs.RegisterDto
{
    public class Registerdto
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
    public class RegisterdtoValidator : AbstractValidator<Registerdto>
    {
        public RegisterdtoValidator()
        {
            RuleFor(product => product.Fullname)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(50).WithMessage("its length dont must 50 ch");
            RuleFor(product => product.Email)
               .NotEmpty().WithMessage("name is required.");
            RuleFor(product => product.Password)
               .NotEmpty().WithMessage("name is required.");
           

        }
    }
}
