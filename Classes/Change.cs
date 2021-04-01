using System;
using System.Collections.Generic;
using System.Text;

namespace CoinChangeProblem
{
    public class Change
    {
        public Change(float changeTotal, float[] permittedCash)
        {
            ChangeTotal = changeTotal;
            OutputChange = CalculateChange(ChangeTotal, permittedCash);

            PrintResult();
        }

        // Permitted cash is assumed to include 0.01 aka 1p!
        public static List<float> CalculateChange(float cost, float[] permittedCash)
        {
            List<float> change = new List<float>();
            Array.Sort(permittedCash, (a, b) => b == a ? 0 : (b < a ? -1 : 1));

            int i = -1;
            while (cost > 0)
            {
                i++;
                float cash = permittedCash[i];

                int n = (int)(cost / cash);
                if (n == 0) continue;

                for (int j = 0; j < n; j++) change.Add(cash);

                cost -= n * cash;
                cost = (float)Math.Round(cost, 2);
            }

            return change;
        }

        public static Change Empty()
        {
            return new Change(0, new float[0]);
        }

        public float ChangeTotal { get; private set; }

        private List<float> changeTotal = new List<float>();
        public IEnumerable<float> OutputChange
        {
            get
            {
                foreach (float f in changeTotal) yield return f;
            }
            set
            {
                changeTotal.Clear();
                foreach (float f in value) changeTotal.Add(f);
            }
        }

        private void PrintResult()
        {
            string changeString = "";
            foreach (float f in OutputChange) changeString += MyStrings.GetMoneyString(f) + ", ";
            if (changeString.Length >= 2) changeString = changeString.Substring(0, changeString.Length - 2);

            Console.WriteLine("Output Change: " + changeString);
        }

    }
}
