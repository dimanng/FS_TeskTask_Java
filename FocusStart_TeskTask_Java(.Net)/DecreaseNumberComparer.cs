using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusStart_TeskTask_Java_.Net_
{
    public class DecreaseNumberComparer : ICompare
    {
        public bool isNotCorrectOrder(string line1, string line2)
        {
            return Convert.ToInt32(line1) < Convert.ToInt32(line2);
        }

        public bool isNextValid(string line1, string line2)
        {
            return Convert.ToInt32(line1) > Convert.ToInt32(line2);

        }
    }
}
