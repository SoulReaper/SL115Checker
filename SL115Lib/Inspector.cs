using System;

namespace SL115Lib
{
    public class Inspector
    {
        private string name;
        private Period bsrLastProvided;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Period BsrLastProvided
        {
            get { return bsrLastProvided; }
            set { bsrLastProvided = value; }
        }
    }
}
