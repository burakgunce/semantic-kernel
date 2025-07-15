using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.SemanticKernel;
using Microsoft.Extensions.DependencyInjection;

var builder = Kernel.CreateBuilder()
                    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();

var promptTemplate = "Yandaki işlemi hesapla: {{$input}}";
var function = kernel.CreateFunctionFromPrompt(promptTemplate);
var arguments = new KernelArguments { ["input"] = "1 + 2 + 5 * 3" };
var result = await function.InvokeAsync(kernel, arguments);
Console.WriteLine(result);

Console.Read();