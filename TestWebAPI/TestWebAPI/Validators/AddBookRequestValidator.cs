using FluentValidation;
using TestWebAPI.Model.Request;

namespace TestWebAPI.Validators
{
    public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
    {
        public AddBookRequestValidator()
        {
            RuleFor(bk => bk.Title)
                .MinimumLength(3).WithMessage("The title must be more than 3 symbols")
                .MaximumLength(35).WithMessage("The title must be less than 35 symbols")
                .NotEmpty();
            RuleFor(bk => bk.Id)
                .NotNull().WithMessage("Id can't be null");               

        }
    }
}
