using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


public class BL_Auto : BL_BASE
{
    private DA_Auto data;

    public List<BE_Auto> Listar_Autos(int Cod_OP, int Orden)
    {
        List<BE_Auto> r = new List<BE_Auto>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Autos(cn, Cod_OP, Orden);
        string fecha = "";
        while (dr.Read())
        {
            BE_Auto i = new BE_Auto();
            i.Cod_OP = dr.Num("Cod_OP");
            i.Des_Doc = dr.Text("Des_Doc");
            fecha = (dr["Fec_Doc"] == null ? null : dr.Text("Fec_Doc"));
            if (fecha == null)
            {
            }
            else
            {
                i.Fec_Doc = "";
                i.Fec_Doc = string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(fecha));
            }
            i.Cod_Auto = dr.Num("Cod_Auto");
            i.Url_Auto = dr.Text("Url_Auto");
            i.File_Name = dr.Text("File_Name");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }


    public int Agregar(BE_Auto oBE_Auto)
    {
        return data.Agregar(oBE_Auto);
    }

    public int Modificar(BE_Auto oBE_Auto)
    {

        return data.Modificar(oBE_Auto);
    }

    public int Eliminar(BE_Auto oBE_Auto)
    {
        return data.Eliminar(oBE_Auto);
    }

    public BL_Auto() { data = new DA_Auto(); }
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

