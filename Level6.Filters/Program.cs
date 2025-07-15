using Codeblaze.SemanticKernel.Connectors.Ollama;
using Level6.Filters.Filters;
using Level6.Filters.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder()
                    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

builder.Services.AddSingleton<IFunctionInvocationFilter, LoggingFilter>();
builder.Services.AddSingleton<IPromptRenderFilter, SafePromptFilter>();
builder.Services.AddSingleton<IAutoFunctionInvocationFilter, EarlyTerminationFilter>();

var kernel = builder.Build();
kernel.Plugins.AddFromType<CalculatorPlugin>();
#region Filter Kernel Properties Implementation
//kernel.FunctionInvocationFilters.Add(new LoggingFilter());
//kernel.PromptRenderFilters.Add(new SafePromptFilter());
//kernel.AutoFunctionInvocationFilters.Add(new EarlyTerminationFilter());
#endregion

#region Function Invocation Filter
//var arguments = new KernelArguments
//{
//    ["number1"] = 3,
//    ["number2"] = 5
//};

//var addResult = await kernel.InvokeAsync(nameof(CalculatorPlugin), "add", arguments);
//Console.WriteLine($"Sonuç : {addResult}");
#endregion
#region Prompt Render Filter
var result = await kernel.InvokePromptAsync("dokuz'un ikiye bölümünden kalan kaçtır?");
Console.WriteLine(result.ToString());
#endregion


Console.Read();