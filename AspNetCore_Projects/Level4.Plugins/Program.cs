using Codeblaze.SemanticKernel.Connectors.Ollama;
using Level4.Plugins.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddKernel()
                .AddOllamaChatCompletion("deepseek-r1", "http://localhost:11434")
                .Plugins.AddFromType<CalculatorPlugin>();

builder.Services.AddRequestTimeouts();
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseRequestTimeouts();

app.MapGet("/add/{number1}/{number2}", async (Kernel kernel, int number1, int number2) =>
{
    var arguments = new KernelArguments
    {
        ["number1"] = number1,
        ["number2"] = number2
    };
    var addResult = await kernel.InvokeAsync("CalculatorPlugin", "add", arguments);
    return addResult.GetValue<int>();
}).WithRequestTimeout(TimeSpan.FromMinutes(10));

app.Run();