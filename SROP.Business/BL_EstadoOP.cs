using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;
public class BL_EstadoOP : BL_BASE
{
    private DA_EstadoOP data;


    public List<SelectListItem> GetsEstadoOrganizacionPolitica()
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_EstadoOP(cn);
        while (dr.Read())
        {
            SelectListItem item = new SelectListItem();
            item.Value = dr.Text("ID_ESTADO_OP");
            item.Text = dr.Text("TX_DESCRIPCION");
            r.Add(item);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_EstadoOP> Listar_EstadoOP()
    {
        List<BE_EstadoOP> r = new List<BE_EstadoOP>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_EstadoOP(cn);
        while (dr.Read())
        {
            BE_EstadoOP i = new BE_EstadoOP();
            i.ID_CODIGO = dr.Text("ID_ESTADO_OP");
            i.TX_DESCRIPCION = dr.Text("TX_DESCRIPCION");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public BL_EstadoOP() { data = new DA_EstadoOP(); }
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

