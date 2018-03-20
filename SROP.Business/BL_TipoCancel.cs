using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_TipoCancel : BL_BASE
{
    private DA_TipoCancel data;

    public List<SelectListItem> Gets2()
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("Cod_Motivo_Cancel");
                item.Text = dr.Text("Des_Motivo_Cancel");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }


    public List<BE_TipoCancel> Gets()
    {
        List<BE_TipoCancel> r = new List<BE_TipoCancel>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Gets(cn);
        while (dr.Read())
        {
            BE_TipoCancel i = new BE_TipoCancel();

            i.Cod_Motivo_Cancel = dr.Text("Cod_Motivo_Cancel");
            i.Des_Motivo_Cancel = dr.Text("Des_Motivo_Cancel");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public BL_TipoCancel() { data = new DA_TipoCancel(); }
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

