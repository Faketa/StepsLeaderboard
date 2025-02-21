using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidationException = FluentValidation.ValidationException;

namespace StepsLeaderboard.Application.Common.Behaviors;

/// <summary>
/// Implements validation behavior for MediatR pipeline.
/// Ensures that incoming requests are validated before execution.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">The collection of validators for the request.</param>
    /// <param name="logger">The logger instance for logging validation details.</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    /// <summary>
    /// Handles the validation logic before the request is processed.
    /// </summary>
    /// <param name="request">The incoming request.</param>
    /// <param name="next">The next delegate in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response from the next handler if validation succeeds.</returns>
    /// <exception cref="ValidationException">Thrown when validation fails.</exception>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Any())
        {
            var validationMessages = failures.Select(f => f.ErrorMessage).ToList();

            _logger.LogWarning("Validation failed for request {RequestType}. Errors: {ValidationErrors}",
                typeof(TRequest).Name, validationMessages);

            throw new FluentValidationException(failures);
        }

        return await next();
    }
}
