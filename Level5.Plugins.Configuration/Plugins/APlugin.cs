using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Level5.Plugins.Configuration.Plugins
{
    public class APlugin
    {
        [KernelFunction("a")]
        [Description("...")]
        [return: Description("...")]
        public void a()
            => Console.WriteLine("A Plugin");
    }
}
