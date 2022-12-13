using System;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit.Abstractions;

namespace Dcn.MinimalApis.Tests.TestHelpers;

public static class ResultExtensions
{
    public static int GetStatusCode(this IResult result)
    {
        if (result is IStatusCodeHttpResult { StatusCode: { } } statusCodeResult)
            return statusCodeResult.StatusCode.Value;

        throw new InvalidOperationException("Could not retrieve status code from result");
    }

    public static object? GetBody(this IResult result)
    {
        if (result is IValueHttpResult valueHttpResult)
            return valueHttpResult.Value;

        throw new InvalidOperationException("Could not retrieve body from result");
    }

    public static T? GetBody<T>(this IResult result)
    {
        if (result is IValueHttpResult<T> valueHttpResult)
            return valueHttpResult.Value;

        throw new InvalidOperationException("Could not retrieve body from result");
    }

    public static void WriteBodyAsJson(this ITestOutputHelper output, IResult result) =>
        output.WriteLine(result.GetBody().SerializeToJson());

    public static void ShouldBe201Created(this IResult result) =>
        result.GetStatusCode().Should().Be(StatusCodes.Status201Created);

    public static void ShouldBe400BadRequest(this IResult result) =>
        result.GetStatusCode().Should().Be(StatusCodes.Status400BadRequest);
}