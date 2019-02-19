using Kompas6API5;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KompasNet
{
    public static class KompasObjectFactory
    {
        public static KompasObject Kompas = null;

        public static void Open()
        {
            string progId = string.Empty;

#if __LIGHT_VERSION__
            progId = "KOMPASLT.Application.5";
#else
            progId = "KOMPAS.Application.5";
#endif
            Process[] pname = Process.GetProcessesByName("KOMPAS");

            if (Kompas == null)
            {
                if (pname.Length == 0)
                    Kompas = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
                else
                {
                    Kompas = (KompasObject)Marshal.GetActiveObject(progId);
                }
            }
            else
            {
                if (pname.Length == 0)
                {
                    Kompas = null;
                    Kompas = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
                }
            }

            Kompas.Visible = true;
        }

        public static void Close()
        {
            if (Kompas != null)
            {
                Process[] pname = Process.GetProcessesByName("KOMPAS");
                if (pname.Length == 0)
                    Kompas.Quit();
                Kompas = null;
            }
        }
    }
}
