using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusStart_TeskTask_Java_.Net_
{
    public class CompareFactory
    {       
        public ICompare CreateComparerByArguments(ArrayList arrArgs)
        {
            ICompare comparer = null;

            if (arrArgs.Contains("-i"))
            {
                if (arrArgs.Contains("-a"))
                {
                    comparer = new IncreaseNumberComparer();
                }
                else if (arrArgs.Contains("-d"))
                {
                    comparer = new DecreaseNumberComparer();
                }
                else
                {
                    comparer = new IncreaseNumberComparer();
                }
            }
            else if (arrArgs.Contains("-s"))
            {
                if (arrArgs.Contains("-a"))
                {
                    comparer = new IncreaseStringComparer();
                }
                else if (arrArgs.Contains("-d"))
                {
                    comparer = new DecreaseStringComparer();
                }
                else
                {
                    comparer = new IncreaseStringComparer();
                }
            }
            return comparer;
        }
    }
}
