using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

// TODO

namespace SLCode
{
    // Handles properties that is global to the app and shared by all other objects. Tried using a static class but this works better as more protection.
    public class BSRGlobal
    {
        private Period m_bsrPeriodAvailable = new Period(); // the latest bsr that can be safely distributed
        private string m_TargetPath;   // where the files are copied to for attachment
        private string m_WorkingDir;   // where the folders and files are on the network drive

        public BSRGlobal()
        {
            this.CalcBSRAvailable();  // needs to be calculated once every time the app runs, unless the app runs accross 23:59 at the end of the month. Not testing for this.
        }

        public string TargetPath
        {
            get { return m_TargetPath; }
            set { m_TargetPath = value; }
        }

        public string WorkingDir
        {
            get { return m_WorkingDir; }
            set { m_WorkingDir = value; }
        }

        // The latest BSR that can be safely distributed = current month - 2
        // month end closing usually around 20th of next month, to be sure report has valid data go back 2 months
        // Stands separate from Inspectors as 1 period applies to all Inspectors
        public Period BSRPeriodAvailable
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
    } // class

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

    } // class Inspector

    // holds the path and filename info, also creates the full path string
    public class Filer
    {
        private string m_stub;
        private string m_fullPath;
       
        
        // path and part of filename just before the branch numder
        public string Stub
        {
            get { return m_stub; }
            set { m_stub = value; }
        }

        // full path + filename + extension
        public string FullPath
        {
            get { return m_fullPath; }
            set { m_fullPath = value; }
        }

    } // class Filer

    // year month
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
            if (period.Length != 6) {  } // do nothing, period must be YYYYMM
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

    } // class Period

    public class BranchCode
    {
        // will only be used as a string outside the class, to keep the property types consistant use strings
        // but do business rules using int, thus string -> int -> string

        private string m_strCode;
        
        public string Number
        {
            get { return m_strCode; }
            set
            {
                uint IntCode; // temporary int version of the branch number
                // strip whitespace, convert to uint, test for 4 digits
                string CleanString = value.Trim();
                Boolean Inted = UInt32.TryParse(CleanString, out IntCode);
                if (Inted == true) // string converted to uint
                {
                    if (IntCode < 10000 && IntCode > 0) { } // value was already assigned to _intCode with TryParse
                    else { IntCode = 0; } // not 1 - 9999, invalid thus assign error code
                }
                else { IntCode = 0; } // int cannot be null, so use 0 as there is no branch number 0
                
                // checking on _intCode is done, now convert back to string for export
                m_strCode = IntCode.ToString();
            }
        }

        // branch code should only be 1 -  9999
        public Boolean IsValid(string branchCode)
        {
            uint IntCode; // temporary int version of the branch number, needed as TryParse assigns a value
            // strip whitespace, convert to uint, test for 4 digits
            string CleanString = branchCode.Trim();
            Boolean Inted = UInt32.TryParse(CleanString, out IntCode); // never use IntCode here, only needed because TryParse forces the value assignment
            if (Inted == true) // string converted to uint
            {
                if (IntCode < 10000 && IntCode > 0) { return true; } // 1 - 9999, valid
                else { return false; } // not 1 - 9999, invalid
            }
            else { return false; } // could not convert to uint, invalid
        }
    } // class Branch
    
} // namespace
