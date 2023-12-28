using FluentValidation;
using Mamba.DTOs.PositionDto;

namespace Mamba.DTOs.CategoryDto
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
    }
    public class CategoryCreateDtoDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(30).WithMessage("its length dont must 30 ch");
        }
    }
}
