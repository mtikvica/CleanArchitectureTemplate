using CleanArchitecture.Application.Abstractions.Behaviors;
using CleanArchitecture.Domain.Abstractions;
using FluentValidation;
using MediatR;
using NSubstitute;

namespace CleanArchitecture.Application.UnitTests.Behaviors;

public class ValidationPipelineBehaviorTests
{
    private class TestRequest : IRequest<Result>
    {
        public required string Name { get; set; }
    }
    private class TestRequestValidator : AbstractValidator<TestRequest>
    {
        public TestRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty.");
        }
    }

    [Fact]
    public async Task Handle_ShouldReturnFailureResult_WhenValidationFails()
    {
        // Arrange
        var validators = new List<IValidator<TestRequest>> { new TestRequestValidator() };
        var behavior = new ValidationPipelineBehavior<TestRequest, Result>(validators);
        var request = new TestRequest { Name = "" };
        var next = Substitute.For<RequestHandlerDelegate<Result>>();

        // Act
        var result = await behavior.Handle(request, next, CancellationToken.None);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal("Validation.General", result.Error.Code);
        await next.DidNotReceive().Invoke();
    }

    [Fact]
    public async Task Handle_ShouldCallNext_WhenValidationSucceeds()
    {
        // Arrange
        var validators = new List<IValidator<TestRequest>>();
        var behavior = new ValidationPipelineBehavior<TestRequest, Result>(validators);
        var request = new TestRequest { Name = "Joe" };
        var next = Substitute.For<RequestHandlerDelegate<Result>>();
        next().Returns(Result.Success());

        // Act
        var result = await behavior.Handle(request, next, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        await next.Received(1).Invoke();
    }
}
