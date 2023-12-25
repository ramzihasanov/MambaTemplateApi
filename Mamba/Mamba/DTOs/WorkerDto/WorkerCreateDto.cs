using FluentValidation;

namespace Mamba.DTOs.WorkerDto
{
    public class WorkerCreateDto
    {
        public string Fullname { get; set; }
        public string ImgUrl { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public string LinkUrl { get; set; }
        public IFormFile formFile { get; set; }
        public List<int> PositionIds { get; set; }

    }
    public class WorkerCreateDtoValidator : AbstractValidator<WorkerCreateDto>
    {
        public WorkerCreateDtoValidator()
        {
            RuleFor(product => product.Fullname)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(50).WithMessage("its length dont must 50 ch");
            RuleFor(product => product.TwitUrl)
               .NotEmpty().WithMessage("name is required.");
            RuleFor(product => product.FaceUrl)
               .NotEmpty().WithMessage("name is required.");
            RuleFor(product => product.InstaUrl)
               .NotEmpty().WithMessage("name is required.");
            RuleFor(product => product.LinkUrl)
               .NotEmpty().WithMessage("name is required.");

        }
    }
}
