using System;
using System.Collections.Generic;
using System.Text;

namespace CoinChangeProblem.Interfaces
{
    public interface ICoinChangeCalculator
    {
        bool CalculatePaymentDue(string timeIn, string timeOut);

        void Pay(float payment);

        Change GetChange();

        void Reset();
    }
}
