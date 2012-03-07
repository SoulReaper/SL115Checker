using System;

namespace SL115Lib
{
    public class Bsr
    {
        private Period m_bsrPeriodAvailable = new Period(); // the latest bsr that can be safely distributed
        
        public Bsr()
        {
            this.CalcBSRAvailable();  // needs to be calculated once every time the app runs, unless the app runs accross 23:59 at the end of the month. Not testing for this.
        }

        // The latest BSR that can be safely distributed = current month - 2
        // month end closing usually around 20th of next month, to be sure report has valid data go back 2 months
        // Stands separate from Inspectors as 1 period applies to all Inspectors
        public Period Available
        {
            get { return m_bsrPeriodAvailable; }
        }

        private void CalcBSRAvailable()
        {
            int yearNow = 0; // today
            int monthNow = 0; // today
            int yearAvailable = 0; // latest BSR that can be used safely
            int monthAvailable = 0; // latest BSR that can be used safely

            yearNow = DateTime.Today.Year;
            monthNow = DateTime.Today.Month;

            // going back 2 months will fall into the previous year, thus now = Jan/Feb
            if (monthNow <= 2)
            {
                yearAvailable = yearNow - 1;
                monthAvailable = monthNow + 10; // october + current month = correct month in the previous year eg. 201101 - 2 = 201011
            }
            else // stay in the same year, just move back 2 months
            {
                yearAvailable = yearNow;
                monthAvailable = monthNow - 2;
            }

            m_bsrPeriodAvailable.Year = yearAvailable;
            m_bsrPeriodAvailable.Month = monthAvailable;
       }
   }
}
