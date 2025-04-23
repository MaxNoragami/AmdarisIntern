using BusinessLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class RegistrationFeeEvaluator : IEvaluator
    {
        public int Evaluate(int? value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

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
