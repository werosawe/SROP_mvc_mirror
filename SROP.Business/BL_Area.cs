using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

public class BL_Area : BL_BASE
{
    private DA_Area data;

    public List<BE_Area> Listar_Areas()
    {
        List<BE_Area> r = new List<BE_Area>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Areas(cn);
        while (dr.Read())
        {
            BE_Area i = new BE_Area();
            i.Cod_Area = dr.Text("Cod_Ente");
            i.Des_Area = dr.Text("Des_Ente");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public BL_Area() { data = new DA_Area(); }
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
