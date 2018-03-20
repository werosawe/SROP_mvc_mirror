using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;
public class BL_Abogado : BL_BASE
{
    private DA_Abogado data;

    public List<SelectListItem> GetsAbogado()
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Abogado(cn);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("USERID");
                item.Text = dr.Text("USERNAME");
                r.Add(item);
            }            
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_Abogado> Listar_Abogado()
    {
        List<BE_Abogado> r = new List<BE_Abogado>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Abogado(cn);
            while (dr.Read())
            {
                BE_Abogado i = new BE_Abogado();
                i.ID_CODIGO = dr.Text("USERID");
                i.TX_DESCRIPCION = dr.Text("USERNAME");
                r.Add(i);
            }           
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BE_Abogado Get_Last_Abogado_OP(BE_Abogado c)
    {
        BE_Abogado i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr=null;
        try
        {
            dr = data.Get_Last_Abogado_OP(cn, c);
            if (dr.Read())
            {
                i = new BE_Abogado();
                i.Abogado_ID = dr.Text("USERID");
                i.Id_Asig_Abogado = dr.Text("id_asig_abogado");
            }         
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_Abogado> Listar_AsistentexOP(int c)
    {
        List<BE_Abogado> r = new List<BE_Abogado>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
           dr = data.Listar_AsistentexOP(cn, c);
            while (dr.Read())
            {
                BE_Abogado i = new BE_Abogado();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Abogado_ID = dr.Text("USERID");
                i.Id_Asig_Abogado = dr.Text("id_asig_abogado");
                i.UserName = dr.Text("UserName");
                i.Fec_Ini = dr.Fec("Fec_ini"); 
                i.Fec_Fin = dr.Fec("Fec_Fin");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public string Agregar(BE_Abogado c)
    {
        return data.Agregar(c);
    }

    public string Eliminar(BE_Abogado oBE_Abogado)
    {
        return data.Eliminar(oBE_Abogado);
    }

    public BL_Abogado()
    {
        data = new DA_Abogado();

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

