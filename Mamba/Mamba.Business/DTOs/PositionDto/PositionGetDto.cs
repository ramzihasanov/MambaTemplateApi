using FluentValidation;

namespace Mamba.DTOs.PositionDto
{
    public class PositionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
    public class PositionGetDtoValidator : AbstractValidator<PositionGetDto>
    {
        public PositionGetDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(30).WithMessage("its length dont must 30 ch");
        }
    }
}
