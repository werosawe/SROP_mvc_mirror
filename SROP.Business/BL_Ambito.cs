using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

using System.Web.Mvc;


public class BL_Ambito : BL_BASE
{
    private DA_Ambito data;


    public List<SelectListItem> GetsAmbito()
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        dr = data.Listar_Ambito(cn);
        while (dr.Read())
        {
            SelectListItem item = new SelectListItem();
            item.Value = dr.Text("COD_AMBITO");
            item.Text = dr.Text("DES_AMBITO");
            r.Add(item);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_Ambito> Listar_Ambito()
    {
        List<BE_Ambito> r = new List<BE_Ambito>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Ambito(cn);
        while (dr.Read())
        {
            BE_Ambito i = new BE_Ambito();
            i.ID_CODIGO = dr.Text("COD_AMBITO");
            i.TX_DESCRIPCION = dr.Text("DES_AMBITO");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public BL_Ambito() { data = new DA_Ambito(); }
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

