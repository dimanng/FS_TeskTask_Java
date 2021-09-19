using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusStart_TeskTask_Java_.Net_
{
    public interface ICompare
    {
        public bool isNextValid(string line1, string line2);

        public bool isNotCorrectOrder(string line1, string line2);


    }
}
