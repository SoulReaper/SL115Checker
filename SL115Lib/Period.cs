using System;
using System.Text;
using System.Collections;

// TODO

/*
 BACKGROUND
 Valid year: 1100 - 9999
 Valid month: 1 - 12
 Throw exception if out of range
*/

namespace SL115Lib
{
    public class Period
    {
        private int m_year;
        private int m_month;
        private int m_minYear = 1100;
        private int m_maxYear = 9999;
        private int m_minMonth = 1;
        private int m_maxMonth = 12;

        #region Constructors

        public Period()  // initialise with minimum values
        {
            Year = MinYear;
            Month = MinMonth;
        }

        public Period(int year, int month)
        {
            Month = month;
            Year = year;
        }

        public Period(string period)
        {
            if (period.Length != 6)
            {
                throw new ArgumentOutOfRangeException("Period", period.Length, "Period must consist of 6 digits in the format YYYYMM.");
            }
            else
            {
                Boolean YearHasParsed = false;
                Boolean MonthHasParsed = false;

                string YearTemp = period.Substring(0, 4);  // extract year
                string MonthTemp = period.Substring(4, 2);  // extract month

                // problem with using field and not a property with tryparse is that it bypasses the integrity checks built into the property
                // cannot use a property with tryparse, so use an intermediary
                int YearTempInt = 0;
                YearHasParsed = Int32.TryParse(YearTemp, out YearTempInt);
                int MonthTempInt = 0;
                MonthHasParsed = Int32.TryParse(MonthTemp, out MonthTempInt);

                // don't test the boolean tryparse values as an exception will be thrown if not converted successfully
                this.Year = YearTempInt;  // will throw exception if int but not within range
                this.Month = MonthTempInt; // will throw exception if int but not within range
            }
        }

        #endregion

        #region Properties

        public int Year
        {
            get { return m_year; }
            set
            {
                if ((value < MinYear) | (value > MaxYear))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Year must be {0} - {1}.", MinYear, MaxYear);
                    throw new ArgumentOutOfRangeException("Year", value, sb.ToString());
                }
                else
                { m_year = value; }
            }
        }

        public int MaxYear
        {
            get { return m_maxYear; }
            set { m_maxYear = value; }
        }

        public int MinYear
        {
            get { return m_minYear; }
            set { m_minYear = value; }
        }

        public int MaxMonth
        {
            get { return m_maxMonth; }
            set { m_maxMonth = value; }
        }

        public int MinMonth
        {
            get { return m_minMonth; }
            set { m_minMonth = value; }
        }

        public int Month
        {
            get { return m_month; }
            set
            {
                if ((value > MaxMonth) | (value < MinMonth))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Month must be {0} - {1}.", MinMonth, MaxMonth);
                    throw new ArgumentOutOfRangeException("Month", value, sb.ToString());
                }
                else m_month = value;
            }
        }

        #endregion 

        #region Operators

        public static bool operator >=(Period p1, Period p2)
        {
            int periodA;
            int periodB;
            periodA = (p1.Year * 100) + p1.Month; // generate integer representation of YYYYMM by adding them together
            periodB = (p2.Year * 100) + p2.Month;
            return periodA >= periodB;
        }

        public static bool operator <(Period p1, Period p2)
        {
            return !(p1 >= p2);
        }

        public static bool operator <=(Period p1, Period p2)
        {
            int periodA, periodB;
            periodA = (p1.Year * 100) + p1.Month;
            periodB = (p2.Year * 100) + p2.Month; // "199912" becomes int 199912
            return periodA <= periodB;
        }

        public static bool operator >(Period p1, Period p2)
        {
            return !(p1 <= p2);
        }

        public static bool operator ==(Period p1, Period p2)
        {
            int periodA, periodB;
            periodA = (p1.Year * 100) + p1.Month;
            periodB = (p2.Year * 100) + p2.Month;
            return periodA == periodB;
        }

        public static bool operator !=(Period p1, Period p2)
        {
            return !(p1 == p2);
        }

        #endregion

        public override bool Equals(object obj)
        {
            return this == (Period)obj;
        }

        public override int GetHashCode()
        {
            return (this.Year * 100) + this.Month; // "198506" -> 198506
        }

        // month should always be 2 digits, add a leading 0 where applicable eg. 201105
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Year);
            if (Month < 10) sb.AppendFormat("0{0}", Month);
            else sb.Append(Month);
            return sb.ToString();
        }

    }
}
