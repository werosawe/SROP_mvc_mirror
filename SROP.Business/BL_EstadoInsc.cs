using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_EstadoInsc : BL_BASE
{

    private DA_EstadoInsc data;

    public List<SelectListItem> Gets2(BE_EstadoInsc c)
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn,c);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("Cod_Estado_Inscrip");
                item.Text = dr.Text("Des_Estado_Inscrip");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_EstadoInsc> Gets(BE_EstadoInsc c)
    {
        List<BE_EstadoInsc> r = new List<BE_EstadoInsc>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn, c);
            while (dr.Read())
            {
                BE_EstadoInsc i = new BE_EstadoInsc();
                i.Cod_Estado_Inscrip = dr.Text("Cod_Estado_Inscrip");
                i.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
                i.FLESTADOOP = dr.Num("flg_estado_OP");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }


    public BE_EstadoInsc Get(BE_EstadoInsc c)
    {
        List<BE_EstadoInsc> r = new List<BE_EstadoInsc>();      
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn, c);
            while (dr.Read())
            {
                BE_EstadoInsc i = new BE_EstadoInsc();
                i.Cod_Estado_Inscrip = dr.Text("Cod_Estado_Inscrip");
                i.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
                i.FLESTADOOP = dr.Num("flg_estado_OP");
                r.Add(i);
            }

            return r.Find(x => x.Cod_Estado_Inscrip == c.Cod_Estado_Inscrip);
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }

    public BL_EstadoInsc() { data = new DA_EstadoInsc(); }
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

