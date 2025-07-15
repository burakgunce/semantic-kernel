using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Level5.Plugins.Configuration.Plugins
{
    public class CPlugin
    {
        [KernelFunction("c")]
        [Description("...")]
        [return: Description("...")]
        public void c()
            => Console.WriteLine("C Plugin");
    }
}
