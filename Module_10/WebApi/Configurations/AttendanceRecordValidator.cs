namespace WebApi.Configurations
{
    using FluentValidation;
    using WebApi.UIModels;

    public class AttendanceRecordUIValidator : AbstractValidator<AttendanceRecordUI>
    {
        public AttendanceRecordUIValidator()
        {
            RuleFor(x => x.Mark).NotEmpty().NotNull().LessThan(6).GreaterThan(0);
            RuleFor(x => x.StudentId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}