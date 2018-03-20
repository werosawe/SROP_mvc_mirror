using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

public class BL_Adherente : BL_BASE
{
    private DA_Adherente data;
    public List<BE_Adherente> Listar_Adherentes(int Cod_OP)
    {
        List<BE_Adherente> r = new List<BE_Adherente>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Adherentes(cn, Cod_OP);
        while (dr.Read())
        {
            BE_Adherente i = new BE_Adherente();
            i.Num_Firmas_Val = dr.Num("Num_Firmas_Val");
            i.Doc_Onpe = dr.Text("Doc_Onpe");
            i.Fec_Doc = dr.Fec("Fec_Doc"); 
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public BE_Adherente Listar_DatosAdherentes(BE_Adherente c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Adherente i = null;
        OracleDataReader dr = data.Listar_DatosAdherentes(cn, c);
        if (dr.Read()) {
            i = new BE_Adherente();
            i.FLCUMPLE = dr.Num("flg_cumple");
            i.Observ = dr.Text("observ");
            i.Num_Firmas_Necesarias = dr.Num("firmas_necesarias");
            i.Num_Firmas_Restantes = dr.Num("firmas_restantes");
            i.Adq_Kit_2016 = dr.Num("adq_kit_2016");
            i.Num_Resol = dr.Text("num_resol");
        }
        pCerrarDr(cn, dr);
        return i;
    }

    public int Agregar(BE_Adherente c)
    {
        return data.Agregar(null, c);
    }

    public int Modificar(BE_Adherente c)
    {

        return data.Actualizar(null, c);
    }

    public int Eliminar(BE_Adherente c)
    {
        return data.Eliminar(null, c);
    }


    public BL_Adherente()
    {
        data = new DA_Adherente();
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

