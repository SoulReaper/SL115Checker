using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SL115Checker
{
    public class Inspector
    {
        public static Period BsrStatic;  // try this to do away with the static class

        private string m_name;
        private Period m_bsrPeriodInspector;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        // the bsr that was last provided to the inspector
        public Period BSRperiod
        {
            get { return m_bsrPeriodInspector; }
            set { m_bsrPeriodInspector = value; }
        }
    }
}
