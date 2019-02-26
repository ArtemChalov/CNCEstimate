using Kompas6API5;
using KompasAPI7;
using KompasNet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KompasNet
{
    public static class KManager
    {
        public static KompasObject Kompas = null;

        public static bool Open(bool visible = true)
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

            Kompas.Visible = visible;

            return Kompas != null;
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

        public static List<KDocumentItem> GetDocumentsNameList()
        {
            Open();

            List<KDocumentItem> list = new List<KDocumentItem>();

            if (KManager.Kompas != null)
            {
                KompasObject Kompas = KManager.Kompas;

                IApplication app = Kompas.ksGetApplication7();

                foreach (IKompasDocument item in app.Documents)
                {
                    if (item.Name.Length > 0)
                        list.Add(new KDocumentItem(item.Name, item.Path, item.Active));
                }
            }

            return list;
        }

        public static bool SetActiveDocument(KDocumentItem kDocument)
        {
            bool output = false;
            List<KDocumentItem> docList = GetDocumentsNameList();
            if (docList.Contains(kDocument) && KManager.Kompas != null)
            {
                KompasObject Kompas = KManager.Kompas;

                IApplication app = Kompas.ksGetApplication7();

                foreach (IKompasDocument item in app.Documents)
                {
                    if (item.Name == kDocument.Name)
                    {
                        item.Active = true;
                        output = true;
                    }
                }
            }
            return output;
        }
    }
}
