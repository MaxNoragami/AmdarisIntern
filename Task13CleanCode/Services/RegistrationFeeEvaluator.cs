using Task13CleanCode.Interfaces;

namespace Task13CleanCode.Services
{
    public class RegistrationFeeEvaluator : ICompute<int>
    {
        public int Compute(int value)
        {
            int registrationFee;

            if (value > 9)
                registrationFee = 0;
            else if (value > 5)
                registrationFee = 50;
            else if (value > 3)
                registrationFee = 100;
            else if (value > 1)
                registrationFee = 250;
            else
                registrationFee = 500;

            return registrationFee;
        }
    }
}
