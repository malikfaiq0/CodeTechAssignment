namespace CodeTechAssignment.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
    {
        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid mobile number format.");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MinimumLength(3).WithMessage("Full name must be at least 3 characters.");

        RuleFor(x => x.Cnic)
            .NotEmpty().WithMessage("CNIC is required.")
            .Matches(@"^\d{13}$").WithMessage("CNIC must be exactly 13 digits.");

        RuleFor(x => x.OtpCode)
            .NotEmpty().WithMessage("OTP code is required.")
            .Length(4).WithMessage("OTP code must be 4 digits.");
    }
}

public class MigrateUserDtoValidator : AbstractValidator<MigrateUserDto>
{
    public MigrateUserDtoValidator()
    {
        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid mobile number format.");

        RuleFor(x => x.OldAccountNumber)
            .NotEmpty().WithMessage("Old account number is required.");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.");
    }
}

public class OtpRequestDtoValidator : AbstractValidator<OtpRequestDto>
{
    public OtpRequestDtoValidator()
    {
        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid mobile number format.");
    }
}

public class OtpVerifyDtoValidator : AbstractValidator<OtpVerifyDto>
{
    public OtpVerifyDtoValidator()
    {
        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid mobile number format.");

        RuleFor(x => x.OtpCode)
            .NotEmpty().WithMessage("OTP code is required.")
            .Length(4).WithMessage("OTP code must be 4 digits.");
    }
}
