using CleanArchitecture.Application.Abstractions.Validation;
using CleanArchitecture.Domain.Abstractions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanArchitecture.Application.Abstractions.Behaviors;
internal sealed class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (validationFailures.Count == 0)
        {
            return await next();
        }

        var errors = CreateValidationError(validationFailures);
        return (TResponse)Result.Failure(errors);
    }

    private static ValidationError CreateValidationError(List<ValidationFailure> validationFailures) =>
             new(validationFailures.Select(f => Error.Problem(f.ErrorCode, f.ErrorMessage)).ToArray());
}