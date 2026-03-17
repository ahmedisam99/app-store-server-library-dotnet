using Enjna.AppStoreServerLibrary.Models.Enums;
using System;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An exception that indicates an App Store Server API error response.
/// </summary>
public sealed class APIException : Exception
{
    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    public int HttpStatusCode { get; }

    /// <summary>
    /// The raw numeric error code from the API response, if available.
    /// </summary>
    public long? RawApiError { get; }

    /// <summary>
    /// The API error code, if it maps to a known <see cref="APIError"/> value.
    /// </summary>
    public APIError? ApiError { get; }

    /// <summary>
    /// The error message from the API response, if available.
    /// </summary>
    public string? ErrorMessage { get; }

    public APIException(int httpStatusCode, long? rawApiError = null, APIError? apiError = null, string? errorMessage = null)
        : base(errorMessage ?? $"App Store Server API error: HTTP {httpStatusCode}")
    {
        HttpStatusCode = httpStatusCode;
        RawApiError = rawApiError;
        ApiError = apiError;
        ErrorMessage = errorMessage;
    }
}
