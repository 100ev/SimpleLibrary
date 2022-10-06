using FluentValidation;
using TestWebAPI.Model.Request;

namespace TestWebAPI.Validators
{
    public class AddAuthorRequestValidator : AbstractValidator<AddAuthorRequest>
    {
        public AddAuthorRequestValidator()
        {
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("My costom message for age less than zero")
                .LessThanOrEqualTo(120).WithMessage("My custom message for age for age greather than 120");
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(150);
            //RuleFor(x => x.NickName)
            //    .MaximumLength(10)
                When(x => !string.IsNullOrEmpty(x.NickName),() =>
             {
                 RuleFor(x => x.NickName)
                 .MinimumLength(2)
                 .MaximumLength(10);
            });
            RuleFor(x => x.DateOfBith)
                .GreaterThan(DateTime.MinValue)
                .LessThan(DateTime.MaxValue);

        }
    }
}
