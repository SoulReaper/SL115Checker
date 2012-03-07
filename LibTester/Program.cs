using System;
using System.Text;
using SL115Lib;

namespace LibTester
{
    class Program
    {
        static void Main(string[] args)
        {
            #region PERIOD
            //*** PERIOD *************************************************
            /*
            Period myPeriodA = new Period();
            Console.WriteLine("Period empty constructor: {0}", myPeriodA.ToString());
            myPeriodA.Year = 1100;
            myPeriodA.Month = 1;
            Console.WriteLine("Period year 1100, month 1: {0} {1} {2}", myPeriodA.ToString(), myPeriodA.Year, myPeriodA.Month);
            
            try
            {
                myPeriodA.Year = 1099;  // this should throw exception
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range. Message: {0}\n", e.Message);
            }
            
            try
            {
                myPeriodA.Month = 0;  // this should throw exception
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range. Message: {0}\n", e.Message);
            }

            try
            {
                myPeriodA.Year = 10000;  // this should throw exception
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range. Message: {0}\n", e.Message);
            }

            try
            {
                myPeriodA.Month = 13;  // this should throw exception
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range. Message: {0}\n", e.Message);
            }
            
            // Test constructor with params
            try
            {
                Period B = new Period("201211"); // valid input
                Console.WriteLine("B: {0}: Year: {1} Month: {2}",B.ToString(), B.Year, B.Month);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range. Message: {0}\n", e.Message);
            }

            // Test invalid strings
            try
            {
                Period C = new Period("a012b1"); // valid input
                Console.WriteLine("C: {0}: Year: {1} Month: {2}", C.ToString(), C.Year, C.Month);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range. Message: {0}\n", e.Message);
            }
            

            Period p1 = new Period("198505");
            Period p2 = new Period("199912");
            Period p3 = new Period("199912");
            
            Console.WriteLine("HashCode for {0}: {1}", p1, p1.GetHashCode()); // 198505
            Console.WriteLine("{0} equals {1}: {2}", p1, p2, p1.Equals(p2));  // false
            Console.WriteLine("{0} equals {1}: {2}\n", p2, p3, p2.Equals(p3));  // true
            
            Console.WriteLine("{0} >= {1}: {2}", p1, p2, p1 >= p2);  // false
            Console.WriteLine("{0} < {1}: {2}", p1, p2, p1 < p2);  // true
            Console.WriteLine("{0} > {1}: {2}", p1, p2, p1 > p2);  // false
            Console.WriteLine("{0} <= {1}: {2}", p1, p2, p1 <= p2);  // true
            Console.WriteLine("{0} == {1}: {2}", p1, p2, p1 == p2);  // false
            Console.WriteLine("{0} != {1}: {2}\n", p1, p2, p1 != p2);  // true
            
            Console.WriteLine("{0} >= {1}: {2}", p2, p1, p2 >= p1);  // true
            Console.WriteLine("{0} < {1}: {2}", p2, p1, p2 < p1);  // false
            Console.WriteLine("{0} > {1}: {2}", p2, p1, p2 > p1);  // true
            Console.WriteLine("{0} <= {1}: {2}", p2, p1, p2 <= p1);  // false
            Console.WriteLine("{0} == {1}: {2}", p2, p3, p2 == p3);  // true
            Console.WriteLine("{0} != {1}: {2}", p2, p3, p2 != p3);  // false
            */
            #endregion

            #region PERIODS
            /*
            Periods Coverage = new Periods();
            Coverage.Add(new Period("201006"));
            Coverage.Add(new Period("199912"));
            Coverage.Add(new Period("201201"));

            foreach (Period myPeriod in Coverage)
            {
                Console.WriteLine("Period in collection: {0}", myPeriod);
            }
            Console.WriteLine();

            for (int i = 0; i < Coverage.Count; i++)
            {
                Console.WriteLine("Element {0}: {1}", i, Coverage[i]);
            }
            Console.WriteLine();

            // Doesn't work: Period, not string. How do I test for a string?
            //Console.WriteLine("Period 199912 is in collection: {0}", Coverage.Contains("199912"));

            */

            #endregion

            #region BSR
            // BSR *****************************************
            /*
            Bsr BSR = new Bsr();
            Period Current = new Period(DateTime.Today.Year, DateTime.Today.Month);

            Console.WriteLine("Current: {0}, Bsr: {1}", Current.ToString(), BSR.Available);
            */
            #endregion

            #region BRANCH

            // *** BRANCH ***************************************
            /*try
            {
                Branch Agency = new Branch(1);
                //Agency.BranchNumber = 1;
                Agency.BranchNumber = Agency.StrToInt("10000");
                Console.WriteLine("Branch code: {0}", Agency.BranchNumber);
                //Console.WriteLine("Branch code: 1 as string valid? {0}", Agency.IsValid(1));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
            #endregion

            #region INSPECTOR
            /*
            Inspector morse = new Inspector();
            // Should have empty constructor as it will be populated when the xml file is loaded
            Console.WriteLine("Name: {0}, last bsr: {1}", morse.Name, morse.LastBsr);
            morse.Name = "Johan Malherbe";
            morse.LastBsr = new Period("201109");
            Console.WriteLine("Name: {0}, last bsr: {1}", morse.Name, morse.LastBsr);
            */
            #endregion

            #region INSPECTORS
            /*
            Inspector a = new Inspector();
            Inspector b = new Inspector();
            Inspector c = new Inspector();
            Inspector d = new Inspector();
            a.Name = "A a";
            a.LastBsr = new Period("199902");
            b.Name = "B b";
            b.LastBsr = new Period("198510");
            c.Name = "C c";
            c.LastBsr = new Period("200211");
            d.Name = "D d";
            d.LastBsr = new Period("201201");
            Inspectors inspectors = new Inspectors();
            //Console.WriteLine("Count: {0}, element 0: {1}", inspectors.Count, inspectors[0]); // should throw exception
            inspectors.Add(a);
            inspectors.Add(b);
            inspectors.Add(c);
            inspectors.Add(d);
            
            Console.WriteLine("Count: {0}, element 2 Name: {1}, bsr: {2}", inspectors.Count, inspectors[2].Name, inspectors[2].LastBsr);
            Console.WriteLine("Contains inspector c: {0}", inspectors.Contains(c));
            
            foreach (Inspector inspector in inspectors)
            {
                Console.WriteLine("Name: {0}, bsr: {1}", inspector.Name, inspector.LastBsr);
            }

            foreach (string name in inspectors.Names)
            {
                Console.WriteLine("Name: {0}", name);
            }

            Console.WriteLine("Inspector named C c is in the collection: {0}", inspectors.Contains("C c"));
            */
            #endregion

            #region FILER



            #endregion


            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        
    }
}
