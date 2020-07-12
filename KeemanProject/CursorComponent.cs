using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeemanProject.Properties
{
    public class CursorComponent
    {
        #region Singleton Marker
        private CursorComponent() { }

        public static CursorComponent Instance => Singleton.Instance;

        private class Singleton
        {
            static Singleton() { }

            internal static CursorComponent Instance { get; } = new CursorComponent();
        }
        #endregion

        #region External dll function 
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadCursorFromFile(string fname);
        #endregion

        #region Properties
        private string CursorDirectory { get; } = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        #endregion

        public Cursor Create(CursorPointerEnum cursor)
        {
            IntPtr cursorLoad = LoadCursorFromFile($"{CursorDirectory}\\Resources\\{cursor.ToString()}.cur");

            if (IntPtr.Zero.Equals(cursorLoad))
            {
                throw new ApplicationException("Cursor could not be found in resources dir, please check!");
                return null;
            }

            return new Cursor(cursorLoad);
        }
    }
}
