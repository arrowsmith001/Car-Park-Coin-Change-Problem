using System;
using System.Collections.Generic;
using System.Text;

namespace CoinChangeProblem
{
    public class CoinChangeCalculatorManager
    {

        private CoinChangeCalculator calc = new CoinChangeCalculator();

        public Change DoTransaction(string timeIn, string timeOut, float[] payment)
        {
            float sum = 0;
            foreach (float f in payment) sum += f;
            return DoTransaction(timeIn, timeOut, sum);
        }

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
