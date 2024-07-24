using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Application.Abstractions.Validation;

public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors) : base(
            "Validation.General",
            "Validation error occurred",
            ErrorType.Validation)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}