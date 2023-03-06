using AmbitionedTask.Models;
using AmbitionedTask.ViewModels;

namespace AmbitionedTask.Services
{
    public interface ICalculatorService
    {
        void Calculate(ExpressionViewModel input);

        Number GetResult();
    }
}
