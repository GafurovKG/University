namespace WebApi.Configurations
{
    using FluentValidation;
    using WebApi.UIModels;

    public class StudentUIPostValidator : AbstractValidator<StudentUIPost>
    {
        public StudentUIPostValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Tel).NotNull().NotEmpty();
        }
    }
}