using CoinChangeProblem.Interfaces;
using System;
using System.Collections.Generic;

namespace CoinChangeProblem
{
    // Assumes our cash reserves are infinite
    public class CoinChangeCalculator : ICoinChangeCalculator
    {
        ICoinChangeClass _coinChangeClass = new CoinChangeClass(); 

        static float[] PermittedCash => new float[] { 20, 10, 5, 1, 0.5f, 0.2f, 0.1f, 0.05f, 0.02f, 0.01f };

        public float PaymentDue { get; private set; }
        public float PaymentReceived { get; private set; }

        public bool CalculatePaymentDue(string timeIn, string timeOut)
        {
            DateTime t1, t2;

            try
            {
                t1 = DateTime.Parse(timeIn);
                t2 = DateTime.Parse(timeOut);
            }
            catch
            {
                Console.WriteLine("Error: Time values are not valid.");
                return false; 
            }

            TimeSpan t = t2 - t1;

            // If negative, that means the time has "rolled over" into the next day, so this adds a day to correct this
            if(t.TotalMinutes <= 0) t += TimeSpan.FromDays(1);

            PaymentDue = CalculatePayment(t.TotalMinutes);

            Console.WriteLine("Time in: " + timeIn + ", " + "Time out: " + timeOut + ", " + "Duration: " + (int)(t.TotalMinutes/60) +"h " + (t.TotalMinutes % 60) + "m");
            Console.WriteLine("OutputCost: " + MyStrings.GetMoneyString(PaymentDue));

            return true;
        }

        public void Pay(float payment)
        {
            PaymentReceived += payment;
        }

        public Change GetChange()
        {
            if(PaymentReceived < PaymentDue)
            {
                Console.WriteLine("Error: Not enough cash inserted." +
                    "\n\tRequired: " + MyStrings.GetMoneyString(PaymentDue) + 
                    "\n\tGiven: " + MyStrings.GetMoneyString(PaymentReceived));
            }

            Console.WriteLine("PaymentReceived: " + MyStrings.GetMoneyString(PaymentReceived));

           
            Change change = _coinChangeClass.CalculateChange(PaymentReceived - PaymentDue, PermittedCash);

            Reset();

            return change;
        }

        public void Reset()
        {
            PaymentDue = 0;
            PaymentReceived = 0;
        }

        private float CalculatePayment(double minutes)
        {
            double output = 3;
            minutes -= 60;

            output += minutes * 0.01;

            return (float) Math.Round(output, 2);
        }
    }


   


    public class MyStrings
    {
        public static string GetMoneyString(float amount)
        {
            if (amount < 1) return (int)(amount * 100) + "p";
            return "£" + amount.ToString("0.00");
        }
    }
}
