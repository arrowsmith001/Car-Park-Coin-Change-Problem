using System;
using System.Collections.Generic;
using System.Text;

namespace CoinChangeProblem
{
    public class Change
    {
        public Change(float changeTotal, List<float> outputChange)
        {
            ChangeTotal = changeTotal;
            OutputChange = outputChange;
        }


        public static Change Empty()
        {
            return new Change(0, new List<float>());
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

        public void Print()
        {
            string changeString = "";
            foreach (float f in OutputChange) changeString += MyStrings.GetMoneyString(f) + ", ";
            if (changeString.Length >= 2) changeString = changeString.Substring(0, changeString.Length - 2);

            Console.WriteLine("Output Change: " + changeString);
        }

    }
}
