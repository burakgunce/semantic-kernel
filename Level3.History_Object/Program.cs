using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder()
                    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();

var history = new ChatHistory();
//İlk mesaj eklenmektedir.
history.AddUserMessage("Merhaba! Bu gün hava nasıl?");

//Model çağrısı yapılmaktadır.
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
var response = await chatCompletionService.GetChatMessageContentAsync(history);

//Response history'e eklenmektedir.
history.AddAssistantMessage(response.ToString());

//Aynı şekilde yeni mesajda history'e eklenerek devam edilir.
history.AddUserMessage("Peki, hafta sonu için hava tahmini nedir?");
var response2 = await chatCompletionService.GetChatMessageContentAsync(history);
history.AddAssistantMessage(response2.ToString());

#region Sohbet Geçmişine Dair Daha Fazla Ayrıntı
//history.Add(new ChatMessageContent()
//{
//    Role = AuthorRole.User,
//    AuthorName = "Gençay Yıldız",
//    Items = [
//        new TextContent{ Text = "Metin Işığın en çok hangi şarkısı sevilmektedir?" },
//        new ImageContent { Uri = new Uri("https://i.ytimg.com/vi/xx_FwxOGBa8/maxresdefault.jpg") }
//    ]
//});
#endregion


Console.WriteLine(response2.ToString());

Console.Read();