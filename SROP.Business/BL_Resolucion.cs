using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


public class BL_Resolucion : BL_BASE
{

    private DA_Resolucion data;

    public List<BE_Resolucion> Listar_Resoluciones(BE_Resolucion c)
    {
        string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
        List<BE_Resolucion> r = new List<BE_Resolucion>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Resoluciones(cn, c);
            while (dr.Read())
            {
                BE_Resolucion i = new BE_Resolucion();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Orden = dr.Text("Orden");
                i.Orden_Show = dr.Text("Orden_Show");
                i.Cod_Tipo_Doc = dr.Text("Cod_Tipo_Doc");
                i.Des_Doc = dr.Text("Des_Doc");
                i.Des_Doc_Show = dr.Text("Des_Doc_Show");
                i.File_Name = dr.Text("File_Name");
                i.Fec_Doc = dr.Fec("Fec_Doc");
                //.Fec_Doc = .Fec_Doc.ToString.Substring(0, 10)
                i.Des_Tipo_Doc = dr.Text("Des_Tipo_Doc");
                i.Observ = dr.Text("Observ");
                i.Url_Resol_Rop = _URL + dr.Text("Url_Resol_Rop");
                i.FLVISIBLE = dr.Num("Flg_Visible");
                i.Fec_Eleva = dr.Fec("Fec_Eleva");
                i.Nro_Resol_Pleno = dr.Text("Nro_Resol_Pleno");
                i.File_Resol_Pleno = dr.Text("File_Resol_Pleno");
                i.Url_Resol_Pleno = dr.Text("Url_Resol_Pleno");
                i.Fec_Resol_Pleno = dr.Fec("Fec_Resol_Pleno");
                i.Des_Resul_Pleno = dr.Text("Des_Resul_Pleno");

                i.Des_Resul_Pleno_Ext = dr.Text("des_resul_pleno_ext");
                i.Nro_Resol_Pleno_Ext = dr.Text("nro_resol_pleno_ext");
                i.Url_Resol_Pleno_Ext = dr.Text("url_resol_pleno_ext");
                i.Fec_Resol_Pleno_Ext = dr.Fec("Fec_Resol_Pleno_Ext");
                c.Orden = i.Orden;
                i.FLTIENEDETALLE = (Listar_ResolucionDetalle(c).Count > 0 ? 1 : 0);
                i.FLTIENEAUTO = dr.Num("flg_autos");
                if ((int)i.FLTIENEAUTO > 0)
                {
                    i.FLTIENEDETALLE = 1;
                }
                i.Des_Tipo_Resol = dr.Text("des_tipo_resol");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_ResolucionDetalle> Listar_ResolucionDetalle(BE_Resolucion c)
    {

        // Simula 2 registros para las resoluciones del pleno y pleno extraordinario

        List<BE_ResolucionDetalle> r = new List<BE_ResolucionDetalle>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_ResolucionDetalle(cn, c);

            if (dr.HasRows)
            {
                if (dr.Text("Nro_Resol_Pleno") != null)
                {
                    BE_ResolucionDetalle i = new BE_ResolucionDetalle();
                    i.Cod_OP = dr.Num("Cod_OP");
                    i.Orden = dr.Num("Orden");

                    i.LabelNroResol = "Nro. Resolución del Pleno:";
                    i.NroResol = dr.Text("Nro_Resol_Pleno");

                    i.LabelFechaResol = "Fecha de Resolución del Pleno:";
                    i.FechaResol = dr.Text("Fec_Resol_Pleno").Substring(0, 10);

                    i.LabelResulResol = "Fallo del Pleno:";
                    i.ResultadoResol = dr.Text("Des_Resul_Pleno");

                    i.Url_Resolucion = dr.Text("Url_Resol_Pleno");


                    r.Add(i);

                }

                if ((dr.Text("Nro_Resol_Pleno_Ext") != null))
                {
                    BE_ResolucionDetalle i = new BE_ResolucionDetalle();

                    i.Cod_OP = dr.Num("Cod_OP");
                    i.Orden = dr.Num("Orden");

                    i.LabelNroResol = "Nro. Resolución del Pleno Extraordinario:";
                    i.NroResol = dr.Text("Nro_Resol_Pleno_Ext");

                    i.LabelFechaResol = "Fecha de Resolución del Pleno Extraordinario:";
                    i.FechaResol = dr.Text("Fec_Resol_Pleno_Ext").Substring(0, 10);

                    i.LabelResulResol = "Fallo del Pleno Extraordinario:";
                    i.ResultadoResol = dr.Text("Des_Resul_Pleno_Ext");

                    i.Url_Resolucion = dr.Text("Url_Resol_Pleno_Ext");

                    r.Add(i);
                }
            }

            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BE_Resolucion Obtener_Resolucion(BE_Resolucion c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Resolucion i = null;
        OracleDataReader dr = null;
        try
        {
            dr = data.Obtener_Resolucion(cn, c);
            if (dr.Read())
            {
                i = new BE_Resolucion();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Cod_Tipo_Doc = dr.Text("Cod_Tipo_Doc");
                i.Orden = dr.Text("Orden");

                i.Des_Doc = dr.Text("Des_Doc");
                i.File_Name = dr.Text("File_Name");
                i.Url_Resol_Rop = dr.Text("url_resol_rop");

                i.Fec_Doc = dr.Fec("Fec_Doc");
                i.Fec_Eleva = dr.Fec("Fec_Eleva");

                i.Nro_Resol_Pleno = dr.Text("Nro_Resol_Pleno");
                i.File_Resol_Pleno = dr.Text("File_Resol_Pleno");
                i.Fec_Resol_Pleno = dr.Fec("Fec_Resol_Pleno");
                i.Cod_Resul_Pleno = dr.Text("Cod_Resul_Pleno");
                i.Url_Resol_Pleno = dr.Text("url_resol_pleno");


                i.Nro_Resol_Pleno_Ext = dr.Text("Nro_Resol_Pleno_Ext");
                i.File_Resol_Pleno_Ext = dr.Text("File_Resol_Pleno_Ext");
                i.Fec_Resol_Pleno_Ext = dr.Fec("Fec_Resol_Pleno_Ext");
                i.Cod_Resul_Pleno_Ext = dr.Text("Cod_Resul_Pleno_Ext");
                i.Url_Resol_Pleno_Ext = dr.Text("url_resol_pleno_ext");

                i.Observ = dr.Text("Observ");
                i.FLVISIBLE = dr.Text("Flg_Visible");

                i.Fec_Notif_Pleno = dr.Fec("Fec_Notif_Pleno");
                i.Fec_Notif_Ext = dr.Fec("Fec_Notif_Ext");

                i.Cod_Tipo_Resol = dr.Text("cod_tipo_resol");
            }
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }


    public List<BE_Resolucion> Listar_Resoluciones_Sueltas()
    {
        string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
        List<BE_Resolucion> r = new List<BE_Resolucion>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Resoluciones_Sueltas(cn);
            while (dr.Read())
            {
                BE_Resolucion i = new BE_Resolucion();
                i.Des_Doc = dr.Text("Des_Doc");
                i.File_Name = dr.Text("File_Name");

                i.Fec_Doc = dr.Fec("Fec_Doc");
                i.Des_Tipo_Doc = dr.Text("Des_Tipo_Doc");
                i.Url_Resol_Rop = _URL + dr.Text("Url_Resol_Rop");
                i.Sumilla = dr.Text("Sumilla");

                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }


    public List<BE_Resolucion> Listar_Tipo_Resol()
    {
        List<BE_Resolucion> r = new List<BE_Resolucion>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Tipo_Resol(cn);
            while (dr.Read())
            {
                BE_Resolucion i = new BE_Resolucion();

                i.Cod_Tipo_Resol = dr.Text("Cod_Tipo_Resol");
                i.Des_Tipo_Resol = dr.Text("Des_Tipo_Resol");

                r.Add(i);
            }

            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }

    public int Resolucion_Repetida(BE_Resolucion c)
    {
        return data.Resolucion_Repetida(c);
    }



    public int Agregar(BE_Resolucion c)
    {
        return data.Agregar(c);
    }

    public int Modificar(BE_Resolucion c)
    {
        return data.Modificar(c);
    }

    public int Eliminar(BE_Resolucion c)
    {
        return data.Eliminar(c);
    }


    public BL_Resolucion() { data = new DA_Resolucion(); }
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

