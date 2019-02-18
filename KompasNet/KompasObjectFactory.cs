using Kompas6API5;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KompasNet
{
    public static class KompasObjectFactory
    {
        private static KompasObject _kompasObject = null;

        public static KompasObject GetKompasObject()
        {
            string progId = string.Empty;

#if __LIGHT_VERSION__
            progId = "KOMPASLT.Application.5";
#else
            progId = "KOMPAS.Application.5";
#endif

            if (_kompasObject == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");

                Process[] pname = Process.GetProcessesByName("KOMPAS");
                if (pname.Length == 0)
                    _kompasObject = (KompasObject)Activator.CreateInstance(t);
                else
                {
                    _kompasObject = (KompasObject)Marshal.GetActiveObject(progId);
                }
            }
            return _kompasObject;
        }
    }
}
