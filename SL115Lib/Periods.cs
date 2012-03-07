using System;
using System.Collections;

namespace SL115Lib
{
    public class Periods : CollectionBase
    {
        public void Add(Period myPeriod)
        {
            List.Add(myPeriod);
        }

        public void Remove(Period myPeriod)
        {
            List.Remove(myPeriod);
        }

        // Indexer
        public Period this[int periodIndex]
        {
            get { return (Period)List[periodIndex]; }
            set { List[periodIndex] = value; }
        }

        // How do I test using a string like "199912" ?
        public bool Contains(Period myPeriod)
        {
            return InnerList.Contains(myPeriod);
        }
    }
}
