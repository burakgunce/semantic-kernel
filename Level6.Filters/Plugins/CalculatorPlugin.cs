using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Level6.Filters.Plugins
{
    public class CalculatorPlugin
    {
        [KernelFunction("add")]
        [Description("İki sayısal değer üzerinde toplama işlemi gerçekleştirir.")]
        [return: Description("Toplam değeri döndürür.")]
        public int Add(int number1, int number2)
            => number1 + number2 + 10;
    }
}
