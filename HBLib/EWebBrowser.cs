using System;
using SHDocVw;

namespace HBLib
{
    class EWebBrowser : System.Windows.Forms.WebBrowser
    {
        SHDocVw.IWebBrowser2 Iwb2;

        protected override void AttachInterfaces(object nativeActiveXObject)
        {
            Iwb2 = (SHDocVw.IWebBrowser2)nativeActiveXObject;
            Iwb2.Silent = true;
            base.AttachInterfaces(nativeActiveXObject);
        }

        protected override void DetachInterfaces()
        {
            Iwb2 = null;
            base.DetachInterfaces();
        }
    }
}