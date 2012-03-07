using System;

// TODO
// InValid(string) does more than one thing. Get a method to convert and one to check if valid.
// Convert and IsValid duplicate code.

namespace SL115Lib
{
    public class Branch
    {
        private int branchNumber;
        private const int MIN_BRANCH_NUMBER = 1;
        private const int MAX_BRANCH_NUMBER = 9999;

        public Branch(int branchNumber)
        {
            BranchNumber = branchNumber;
        }

        public int BranchNumber
        {
            get { return branchNumber; }
            set 
            {
                if (this.IsValidBranchNumber(value))
                {
                   branchNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("BranchNumber", value, "Branch number must be 1 - 9999");
                }
            }
        }

        public Boolean IsValidBranchNumber(int branchNumber)
        {
            if (branchNumber <= MAX_BRANCH_NUMBER && branchNumber >= MIN_BRANCH_NUMBER) { return true; } // 1 - 9999, valid
            else { return false; }
        }

        // branch code should only be 1 -  9999
        public Boolean IsValidBranchNumber(string branchNumber)
        {
            int IntCode; // temporary int version of the branch number, needed as TryParse assigns a value
            // strip whitespace, convert to uint, test for 4 digits
            string CleanString = branchNumber.Trim();
            Boolean Inted = Int32.TryParse(CleanString, out IntCode); // never use IntCode here, only needed because TryParse forces the value assignment
            if (Inted == true) // string converted to uint
            {
                if (IntCode <= MAX_BRANCH_NUMBER && IntCode >= MIN_BRANCH_NUMBER) { return true; } // 1 - 9999, valid
                else { return false; } // not 1 - 9999, invalid
            }
            else { return false; } // could not convert to uint, invalid
        }

        public int StrToInt(string branchCode)
        {
            int IntCode; // temporary int version of the branch number, needed as TryParse assigns a value
            // strip whitespace, convert to uint, test for 4 digits
            string CleanString = branchCode.Trim();
            Boolean Inted = Int32.TryParse(CleanString, out IntCode); 
            if (Inted == true) // string converted to uint
            {
                if (IntCode < 10000 && IntCode > 0) { return IntCode; } // 1 - 9999, valid
                else { throw new ArgumentOutOfRangeException("BranchNumber", IntCode, "Branch number must be 1 - 9999"); } // not 1 - 9999, invalid
            }
            else { throw new ArgumentOutOfRangeException("BranchNumber", IntCode, "Branch number must be 1 - 9999"); } // could not convert to uint, invalid
        }
         
    }
}
