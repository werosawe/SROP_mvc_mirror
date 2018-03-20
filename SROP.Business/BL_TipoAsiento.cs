using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_TipoAsiento : BL_BASE
{
    private DA_TipoAsiento data;


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
                SelectListItem item = new SelectListItem
                {
                    Value = dr.Text("Cod_Tipo_Asiento"),
                    Text = dr.Text("Des_Tipo_Asiento")
                };
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }


    public List<BE_TipoAsiento> Gets()
    {
        List<BE_TipoAsiento> r = new List<BE_TipoAsiento>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn);
            while (dr.Read())
            {
                BE_TipoAsiento i = new BE_TipoAsiento();
                i.Cod_Tipo_Asiento = dr.Text("Cod_Tipo_Asiento");
                i.Des_Tipo_Asiento = dr.Text("Des_Tipo_Asiento");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }

    public BL_TipoAsiento() { data = new DA_TipoAsiento(); }
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

