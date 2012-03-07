using System;
using System.Collections;

namespace SL115Lib
{
    public class Inspectors: CollectionBase
    {
        public void Add(Inspector inspector)
        {
            List.Add(inspector);
        }

        public void Remove(Inspector inspector)
        {
            List.Remove(inspector);
        }

        public Inspector this[int inspectorIndex]
        {
            get { return (Inspector)List[inspectorIndex]; }
            set { List[inspectorIndex] = value; }
        }

        public bool Contains(Inspector inspector)
        {
            return InnerList.Contains(inspector);
        }

        // test for inspector.name i.e. contains("Johan") instead of object name
        public bool Contains(string name)
        {
            bool foundName = false;
            foreach (Inspector inspector in List)
            {
                if (inspector.Name == name)
                {
                    foundName = true; // don't make it false if not found, need to be found only once to be successful
                }
            }
            return foundName; // initialised as false, so need to return false.
        }

        public IEnumerable Names
        {
            get
            {
                foreach (Inspector inspector in List)
                {
                    yield return inspector.Name;
                }
            }
        }
    }
}
