using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_Ente : BL_BASE
{
    private DA_Ente data;

    //If ShowMsg_InCombo Then
    //      CBO.Items.Add(New ListItem("", ""))
    //    End If

    //    For i As Integer = 2003 To Year(Date.Now)
    //        CBO.Items.Add(New ListItem(i.ToString, i.ToString))
    //    Next


 

    public List<SelectListItem> GetsPrefijoExpedienteMTD(BE_Ente c)
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetsPrefijoExpedienteMTD(cn, c);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("Prefijo_MTD");
                item.Text = dr.Text("Prefijo_MTD");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    //public List<BE_Ente> GetsTipoExpedienteMTD2(BE_Ente c)
    //{
    //    List<BE_Ente> r = new List<BE_Ente>();
    //    OracleConnection cn = new OracleConnection(TX_ESQUEMA);
    //    OracleDataReader dr = null;
    //    try
    //    {
    //        dr = data.GetsPrefijoExpedienteMTD(cn, c);
    //        while (dr.Read())
    //        {
    //            BE_Ente i = new BE_Ente();
    //            i.Prefijo_MTD = dr.Text("Prefijo_MTD");
    //            r.Add(i);
    //        }
    //        return r;
    //    }
    //    finally {
    //        pCerrarDr(cn, dr);
    //    }
    //}


    public List<SelectListItem> GetsEnte()
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetsEnte(cn);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("Cod_Ente");
                item.Text = dr.Text("Des_Ente");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    //public List<BE_Ente> GetsEnte()
    //{
    //    List<BE_Ente> r = new List<BE_Ente>();
    //    OracleConnection cn = new OracleConnection(TX_ESQUEMA);
    //    OracleDataReader dr = null;
    //    try
    //    {
    //        dr = data.GetsEnte(cn);
    //        while (dr.Read())
    //        {
    //            BE_Ente i = new BE_Ente();
    //            i.Cod_Ente = dr.Text("Cod_Ente");
    //            i.Des_Ente = dr.Text("Des_Ente");
    //            r.Add(i);
    //        }
    //        return r;
    //    }
    //    finally
    //    {
    //        pCerrarDr(cn, dr);
    //    }
    //}

    public List<BE_Ente> Listar_Entes_Const(string Cod_Ente)
    {
        List<BE_Ente> r = new List<BE_Ente>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Entes_Const(cn, Cod_Ente);
        while (dr.Read())
        {
            BE_Ente i = new BE_Ente();
            i.Cod_Ente = dr.Text("Cod_Ente");
            i.Des_Ente = dr.Text("Des_Ente_Corto");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }


    public BE_Ente Get_Responsable_Ente(string Cod_Ente)
    {
        BE_Ente i = new BE_Ente();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Get_Responsable_Ente(cn, Cod_Ente);
        while (dr.Read())
        {
            i.Responsable_Ente = dr.Text("responsable_constancia");
            i.Cargo_Responsable = dr.Text("txcargo_responsable");
            i.Logo1 = dr.Text("logo1");
            i.Logo2 = dr.Text("logo2");
        }
        pCerrarDr(cn, dr);
        return i;
    }

    public List<BE_Ente> Listar_TiposEntes()
    {
        List<BE_Ente> r = new List<BE_Ente>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_TiposEntes(cn);
        while (dr.Read())
        {
            BE_Ente i = new BE_Ente();
            i.Cod_Ente = dr.Text("Cod_Ente");
            i.Des_Ente = dr.Text("Des_Ente");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public BL_Ente() { data = new DA_Ente(); }
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

