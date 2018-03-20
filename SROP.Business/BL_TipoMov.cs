using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_TipoMov : BL_BASE
{
    private DA_TipoMov data;

    public List<SelectListItem> Gets()
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
                item.Value = dr.Text("Cod_Tipo_Movim");
                item.Text = dr.Text("Des_Tipo_Movim");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }
    
    //public List<BE_TipoMov> Gets()
    //{
    //    List<BE_TipoMov> r = new List<BE_TipoMov>();
    //    OracleConnection cn = new OracleConnection(TX_ESQUEMA);
    //    OracleDataReader dr = null;
    //    try
    //    {
    //        dr = data.Gets(cn);
    //        while (dr.Read())
    //        {
    //            BE_TipoMov i = new BE_TipoMov();
    //            i.Cod_Tipo_Movim = dr.Text("Cod_Tipo_Movim");
    //            i.Des_Tipo_Movim = dr.Text("Des_Tipo_Movim");
    //            i.Enableddlestado = dr.Text("Enableddlestado");
    //            r.Add(i);
    //        }
    //        return r;
    //    }
    //    finally
    //    {
    //        pCerrarDr(cn, dr);
    //    }
    //}

    public BL_TipoMov() { data = new DA_TipoMov(); }
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

