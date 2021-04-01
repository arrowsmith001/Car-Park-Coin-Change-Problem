using System;
using System.Collections.Generic;

namespace CoinChangeProblem
{
    public class CoinChangeClass : ICoinChangeClass
    {
        public Change CalculateChange(float cost, float[] permittedCash)
        {
            List<float> change = new List<float>();
            Array.Sort(permittedCash, (a, b) => b == a ? 0 : (b < a ? -1 : 1));

            float costTemp = cost;

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

            return new Change(costTemp, change);
        }
    }
}