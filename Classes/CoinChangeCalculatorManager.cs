using CoinChangeProblem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinChangeProblem
{
    public class CoinChangeCalculatorManager : ICoinChangeCalculatorManager
    {

        private ICoinChangeCalculator calc = new CoinChangeCalculator();

        public Change DoTransaction(string timeIn, string timeOut, float payment)
        {
            Console.WriteLine();

            calc.Reset();

            if (!calc.CalculatePaymentDue(timeIn, timeOut)) return Change.Empty();

            calc.Pay(payment);

            return calc.GetChange();
        }

        
    }
}
