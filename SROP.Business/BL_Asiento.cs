using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


public class BL_Asiento : BL_BASE
{
    private DA_Asiento data;

    //private string formatoFechaInterfaz = "dd-MMM-yyyy";

    public List<BE_Asiento> Gets(BE_Asiento c)
    {
        string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
        List<BE_Asiento> r = new List<BE_Asiento>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn, c);
            while (dr.Read())
            {
                BE_Asiento i = new BE_Asiento();
                i.Cod_OP = dr.Num("Cod_OP");                
                i.Num_Asiento = dr.Num("Num_Asiento");
                i.Asiento = dr.Text("Asiento").Replace(".pdf", "");
                i.Fec_Asiento = dr.Fec("Fec_Asiento");
                i.Observ = dr.Text("Observ");
                i.Url_Asiento = _URL + dr.Text("Url_Asiento");
                i.Cod_Tipo_Asiento = dr.Text("Cod_Tipo_Asiento");
                i.Des_Tipo_Asiento = dr.Text("Des_Tipo_Asiento");
                i.Asiento_Numero = "Asiento N° " + dr.Num("Num_Asiento").CerosIzquierda(3);
                r.Add(i);
            }            
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }

    public BE_Asiento Get(BE_Asiento c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Asiento i = new BE_Asiento();
        OracleDataReader dr = null;
        try
        {
            dr = data.Get(cn, c);
            if (dr.Read())
            {
                i.Cod_OP = dr.Num("Cod_OP");
                //.Show_Num_Asiento = Dame_Entero(dr("Show_Num_Asiento"))
                i.Num_Asiento = dr.Num("Num_Asiento");
                i.Asiento = dr.Text("Asiento");
                i.Fec_Asiento = dr.Fec("Fec_Asiento");
                i.Observ = dr.Text("Observ");
                i.Url_Asiento = dr.Text("Url_Asiento");
                i.Cod_Tipo_Asiento = dr.Text("Cod_Tipo_Asiento");
                i.Des_Tipo_Asiento = dr.Text("Des_Tipo_Asiento");
            }            
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }

    public List<BE_Asiento> Lista_FiltroFechas(BE_BusquedaOP.FecEstado paramFec, List<BE_Asiento> Lista)
    {

        if (paramFec.FecIni==null)
        {
            return Lista;
        }

        if (paramFec.FecFin ==null)
        {
            paramFec.FecFin = DateTime.Today;
        }
        List<BE_Asiento> LISTA_Asientos = new List<BE_Asiento>();

        if (Lista.Count == 0)
        {

        }
        else
        {
            DateTime? dt1 = paramFec.FecIni; // DateTime.ParseExact(paramFec.FecIni, formatoFechaInterfaz, null);
            DateTime? dt2 = paramFec.FecFin; // DateTime.ParseExact(paramFec.FecFin, formatoFechaInterfaz, null);
            DateTime? dateAsiento = default(System.DateTime);

            foreach (BE_Asiento x in Lista)
            {
                if (x.Fec_Asiento == null)
                {
                }
                else
                {
                    //dateAsiento = DateTime.ParseExact(x.Fec_Asiento.Substring(0, 10), "dd/MM/yyyy", Nothing)
                    dateAsiento = x.Fec_Asiento;
                    if ((dateAsiento.Value.Date >= dt1.Value.Date) & (dateAsiento.Value.Date <= dt2.Value.Date))
                    {
                        LISTA_Asientos.Add(x);
                    }
                }
            }

        }

        return (LISTA_Asientos);

    }

    public int Agregar(BE_Asiento c)
    {
        return data.Agregar(c);
    }

    public int Modificar(BE_Asiento c)
    {
        return data.Modificar(c);
    }

    public int Eliminar(BE_Asiento c)
    {
        return data.Eliminar( c);
    }

    public int Modificar_FechaCarga_Directivos(BE_Asiento c)
    {
        return data.Modificar_FechaCarga_Directivos( c);
    }


    public BE_Asiento.ret_HistCargo Busca_Asiento_Historial_Cargos(BE_Asiento c)
    {
        return data.Busca_Asiento_Historial_Cargos(null, c);
    }

    public BL_Asiento() { data = new DA_Asiento(); }
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

