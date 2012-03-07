using System;

namespace SL115Lib
{
    public class Filer
    {
        private string m_stub;  // path and part of filename just before the branch number
        private string m_fullPath;  // full path + filename + extension
        public static string TargetPath;   // where the files are copied to for attachment (shared amongst all objects)
        public static string WorkingDir;   // where the folders and files are on the network drive (shared anongst all objects)
        
        public string Stub
        {
            get { return m_stub; }
            set { m_stub = value; }
        }
        
        public string FullPath
        {
            get { return m_fullPath; }
            set { m_fullPath = value; }
        }

    }
}
