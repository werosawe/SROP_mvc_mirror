using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

public class BL_ActaFundacion : BL_BASE
{
    private DA_ActaFundacion data;
    public List<BE_ActaFundacion> Listar_ActasFundacion(BE_OP c)
    {
        List<BE_ActaFundacion> r = new List<BE_ActaFundacion>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_ActasFundacion(cn, c);
        while (dr.Read())
        {
            BE_ActaFundacion i = new BE_ActaFundacion();
            i.Cod_OP = dr.Num("Cod_OP");
            i.Cod_Req = dr.Text("Cod_Req");
            i.Cod_Item = dr.Text("Cod_Item");
            i.Des_Item = dr.Text("Des_Item");
            i.FLTITULO = dr.Num("Flg_Titulo");
            i.Art_Doc = dr.Text("Art_Doc");
            i.FLCUMPLE = dr.Num("Flg_Cumple");
            i.Observ = dr.Text("Observ");
            i.Art_Ley = dr.Text("Art_Ley");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public int Grabar_Registros(BE_ActaFundacion c)
    {
        return data.Grabar_Registros(c);
    }

    public int Grabar_CheckReq(BE_ActaFundacion c)
    {
        return data.Grabar_CheckReq(c);
    }

    public BL_ActaFundacion()
    {
        data = new DA_ActaFundacion();
    }

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

