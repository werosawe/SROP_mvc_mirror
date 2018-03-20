using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


public class BL_Estatuto : BL_BASE
{
    private DA_Estatuto data;

    public List<BE_Estatuto> Gets(BE_Estatuto c)
    {
        string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
        List<BE_Estatuto> r = new List<BE_Estatuto>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn, c);
            while (dr.Read())
            {
                BE_Estatuto i = new BE_Estatuto();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Orden = dr.Num("Orden");
                i.OrdenShow = dr.Num("OrdenShow");
                i.Des_Doc = dr.Text("Des_Doc");
                i.File_Name = dr.Text("File_Name");
                i.Fec_Doc = dr.Fec("Fec_Doc");
                i.Des_Tipo_Doc = dr.Text("Des_Tipo_Doc");
                i.Observ = dr.Text("Observ");
                i.Url_Estatuto_OP = _URL + dr.Text("Url_Estatuto_OP");
                i.Anos_Vigencia_Cargo = dr.Num("Anos_Vigencia_Cargo");
                i.FLVISIBLE = dr.Num("Flg_Visible");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BE_Estatuto Get(BE_Estatuto c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Estatuto i = null;
        OracleDataReader dr = null;
        try
        {
            dr = data.Get(cn, c);
            if (dr.Read())
            {
                i = new BE_Estatuto();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Orden = dr.Num("Orden");
                i.Des_Doc = dr.Text("Des_Doc");
                i.File_Name = dr.Text("File_Name");
                i.Fec_Doc = dr.Fec("Fec_Doc");
                i.FLVISIBLE = dr.Num("Flg_Visible");
            }
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }




    public int Agregar(BE_Estatuto c)
    {
        return data.Agregar(c);
    }

    public int Modificar(BE_Estatuto c)
    {
        return data.Modificar(c);
    }

    public int Eliminar(BE_Estatuto c)
    {

        return data.Eliminar(c);
    }


    public BL_Estatuto() { data = new DA_Estatuto(); }
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

