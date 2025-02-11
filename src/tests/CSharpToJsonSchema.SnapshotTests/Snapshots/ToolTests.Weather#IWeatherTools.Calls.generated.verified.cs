﻿//HintName: IWeatherTools.Calls.generated.cs
#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public static partial class WeatherToolsExtensions
    {
        public class GetCurrentWeatherArgs
        {
            public string Location { get; set; } = string.Empty;
            public global::CSharpToJsonSchema.IntegrationTests.Unit Unit { get; set; }
        }

        public class GetCurrentWeatherAsyncArgs
        {
            public string Location { get; set; } = string.Empty;
            public global::CSharpToJsonSchema.IntegrationTests.Unit Unit { get; set; }
        }

        public static global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls(this IWeatherTools service)
        {
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {
                ["GetCurrentWeather"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(service.CallGetCurrentWeather(json));
                },
 
                ["GetCurrentWeatherAsync"] = async (json, cancellationToken) =>
                {
                    return await service.CallGetCurrentWeatherAsync(json, cancellationToken);
                },
 
            };
        }

        public static WeatherToolsExtensions.GetCurrentWeatherArgs AsGetCurrentWeatherArgs(
            this IWeatherTools functions,
            string json)
        {
            return
                global::System.Text.Json.JsonSerializer.Deserialize<WeatherToolsExtensions.GetCurrentWeatherArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
        }

        public static WeatherToolsExtensions.GetCurrentWeatherAsyncArgs AsGetCurrentWeatherAsyncArgs(
            this IWeatherTools functions,
            string json)
        {
            return
                global::System.Text.Json.JsonSerializer.Deserialize<WeatherToolsExtensions.GetCurrentWeatherAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
        }

        public static string CallGetCurrentWeather(this IWeatherTools functions, string json)
        {
            var args = functions.AsGetCurrentWeatherArgs(json);
            var jsonResult = functions.GetCurrentWeather(args.Location, args.Unit);

            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
        }

 

        public static async global::System.Threading.Tasks.Task<string> CallGetCurrentWeatherAsync(
            this IWeatherTools functions,
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = functions.AsGetCurrentWeatherAsyncArgs(json);
            var jsonResult = await functions.GetCurrentWeatherAsync(args.Location, args.Unit, cancellationToken);

            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
        }

 

        public static async global::System.Threading.Tasks.Task<string> CallAsync(
            this IWeatherTools service,
            string functionName,
            string argumentsAsJson,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var calls = service.AsCalls();
            var func = calls[functionName];

            return await func(argumentsAsJson, cancellationToken);
        }
    }
}