using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.Database;
using System.Reflection;

namespace CleanArchitecture.ArchitectureTests;
public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Result).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(IUnitOfWork).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}
