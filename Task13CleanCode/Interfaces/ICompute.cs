using System.Numerics;
using Task13CleanCode.Entities;

namespace Task13CleanCode.Interfaces
{
    public interface ICompute<T> where T : INumber<T>
    {
        public T Compute(T value);
    }
}
