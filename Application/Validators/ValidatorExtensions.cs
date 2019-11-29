using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {

        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder.NotEmpty().MinimumLength(6).
                WithMessage("Password must be at least 6 characters long").Matches("[A-Z]").
                WithMessage("Password must contain at least one upper case letter.").Matches("[a-z]").
                WithMessage("Password must contain at least one lower case letter.")
                .Matches("[0-9]").WithMessage("Password must contain a number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain a non alphanumeric.");
            return options;
        }

    }
}