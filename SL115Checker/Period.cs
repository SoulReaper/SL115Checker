using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SL115Checker
{
    public class Period
    {
        private int m_year;
        private int m_month;

        public int Year
        {
            get { return m_year; }
            set { m_year = value; }
        }

        public int Month
        {
            get { return m_month; }
            set // keep month 1 - 12
            {
                if (value > 12) m_month = 12;
                else if (value < 1) m_month = 1;
                else m_month = value;
            }
        }

        // month should always be 2 digits, add a leading 0 where applicable eg. 201105
        override public string ToString()
        {
            if (m_month < 10) return m_year.ToString() + "0" + m_month.ToString();
            else return m_year.ToString() + m_month.ToString();
        }

        public Period(string period)
        {
            if (period.Length != 6) { } // do nothing, period must be YYYYMM
            else
            {
                Boolean YearHasParsed = false;
                Boolean MonthHasParsed = false;
                string YearTemp = period.Substring(0, 4);  // extract year
                string MonthTemp = period.Substring(4, 2);  // extract month
                YearHasParsed = Int32.TryParse(YearTemp, out m_year);
                MonthHasParsed = Int32.TryParse(MonthTemp, out m_month);
                if (MonthHasParsed == false || YearHasParsed == false) // error with parse, do default values
                {
                    m_year = 1100;
                    m_month = 1;
                }
                // No else statement as it is already handled by TryParse
            }
        }

        public Period()
        {
            m_year = 1100;
            m_month = 1;
        }
    }
}
