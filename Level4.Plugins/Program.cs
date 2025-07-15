using Codeblaze.SemanticKernel.Connectors.Ollama;
using Level4.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder()
                    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();

kernel.Plugins.AddFromType<CalculatorPlugin>();

//var arguments = new KernelArguments
//{
//    ["number1"] = 3,
//    ["number2"] = 5
//};

//var addResult = await kernel.InvokeAsync("CalculatorPlugin", "add", arguments);
//Console.WriteLine($"Sonuç : {addResult}");


#region Plugin'in Otomatik Çağrılması
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
var result = await chatCompletionService.GetChatMessageContentAsync(
    "üç ve beş'in toplamını hesapla",
    executionSettings: new PromptExecutionSettings
    {
        FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
    },
    kernel: kernel
    );


Console.WriteLine(result.ToString());
#endregion

Console.Read();