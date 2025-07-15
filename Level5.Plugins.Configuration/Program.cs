using Codeblaze.SemanticKernel.Connectors.Ollama;
using Level5.Plugins.Configuration.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder()
                    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();

kernel.Plugins.AddFromType<APlugin>();
kernel.Plugins.AddFromType<BPlugin>();
kernel.Plugins.AddFromType<CPlugin>();

#region Prompt'a göre otomatik eklentileri devreye sokma
//PromptExecutionSettings promptExecutionSettings = new()
//{
//    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
//};
#endregion
#region Otomatik devreye girebilecek eklenti fonksiyonlarını seçme
//PromptExecutionSettings promptExecutionSettings = new()
//{
//    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(functions: [
//        kernel.Plugins.GetFunction(nameof(APlugin), "a"),
//        kernel.Plugins.GetFunction(nameof(CPlugin), "c")
//        ])
//};
#endregion
#region Tüm eklentileri devre dışı bırakma
//PromptExecutionSettings promptExecutionSettings = new()
//{
//    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(functions: [])
//};
#endregion
#region Modeli en az bir eklenti seçmeye zorlama
//PromptExecutionSettings promptExecutionSettings = new()
//{
//    FunctionChoiceBehavior = FunctionChoiceBehavior.Required()
//};
#endregion
#region Modeli en az bir eklenti seçmeye zorlama
PromptExecutionSettings promptExecutionSettings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.None()
};
#endregion

await kernel.InvokePromptAsync("...", new(promptExecutionSettings));

Console.Read();