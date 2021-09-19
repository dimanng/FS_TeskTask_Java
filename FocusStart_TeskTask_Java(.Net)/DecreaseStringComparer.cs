using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusStart_TeskTask_Java_.Net_
{
    public class DecreaseStringComparer : ICompare
    {
        public bool isNotCorrectOrder(string line1, string line2)
        {
            return line1.CompareTo(line2) < 0;
        }

        public bool isNextValid(string line1, string line2)
        {
            return line1.CompareTo(line2) >= 0;
        }
    }
}
