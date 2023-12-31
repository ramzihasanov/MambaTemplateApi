﻿using FluentValidation;

namespace Mamba.DTOs.PositionDto
{
    public class PositionCreateDto
    {
        public string Name { get; set; }      
    }
    public class PositionCreateDtoValidator : AbstractValidator<PositionCreateDto>
    {
        public PositionCreateDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(30).WithMessage("its length dont must 30 ch");
        }
    }
}
