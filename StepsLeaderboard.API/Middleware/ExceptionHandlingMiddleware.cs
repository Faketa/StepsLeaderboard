using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidationException = FluentValidation.ValidationException;

namespace StepsLeaderboard.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        object errorResponse;
        int statusCode;

        switch (exception)
        {
            case FluentValidationException validationException:
                statusCode = (int)HttpStatusCode.BadRequest;
                var validationErrors = validationException.Errors.Select(e => e.ErrorMessage).ToList();
                errorResponse = new { Message = "Validation failed.", Errors = validationErrors };
                break;

            case KeyNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                errorResponse = new { Message = exception.Message };
                break;

            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse = new { Message = "An unexpected error occurred." };
                break;
        }

        response.StatusCode = statusCode;
        var json = JsonSerializer.Serialize(errorResponse);
        return response.WriteAsync(json);
    }
}
