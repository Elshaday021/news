using FluentValidation;
using HCMS.Services.DataService;

namespace HCMS.Application.Features.Jobs.JobGrades.Validation
{
    public class AddJobGradeCommandValidator : AbstractValidator<AddJobGradeCommand>
    {
        private readonly IDataService dataService;

        public AddJobGradeCommandValidator(IDataService dataService)
        {
            this.dataService = dataService;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.").NotNull();

            RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required.").NotNull();

            RuleFor(p => p).Must(IsJobGradeUnique).WithMessage("Job Grade Name Already Exist");
        }
        private bool IsJobGradeUnique(AddJobGradeCommand command) => !dataService.JobGrades.Any(x => x.Name == command.Name);
    }
}