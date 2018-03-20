using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;
using System.Web;

public class BL_Error : BL_BASE
{
    private DA_Error data;
    public void ADD(BE_Error c)
    {
        data.ADD(c);
    }

    public static void ADD(Exception ex)
    {
        int STATUSCODE = new HttpException(null, ex).GetHttpCode();
        string MENSAJE = ex.Message;
        string ORIGEN = ex.Source.Text() + " - " + ex.TargetSite.ToString();
        BL_Error b = new BL_Error();
        BE_Error i = new BE_Error();
        try
        {
            i.TXERROR = MENSAJE;
            i.TXORIGEN = ORIGEN;
            i.NUSTATUSCODE = STATUSCODE;
        }
        finally
        {
            b.ADD(i);
            b.Dispose(); b = null;
        }
    }

        public BL_Error() { data = new DA_Error(); }
    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            data.Dispose(); data = null;
        }
        disposed = true;
        base.Dispose(disposing);
    }
}

//public class BL_Error2 : BL_BASE
//{
//}