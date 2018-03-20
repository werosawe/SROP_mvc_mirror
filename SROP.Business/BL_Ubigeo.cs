using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_Ubigeo : BL_BASE
{
    private DA_Ubigeo data;


    public List<SelectListItem> GetsDistrito(BE_UBIGEO c)
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Distritos(cn, c);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("UBIDISTRITO");
                item.Text = dr.Text("DISTRITO");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<SelectListItem> GetsProvincia(BE_UBIGEO c)
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Provincias(cn,c);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("UBIPROVINCIA");
                item.Text = dr.Text("PROVINCIA");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }


    public List<SelectListItem> GetsDepartamento()
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Regiones(cn);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.Text("UBIREGION");
                item.Text = dr.Text("REGION");
                r.Add(item);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_UBIGEO> Listar_Regiones()
    {
        List<BE_UBIGEO> r = new List<BE_UBIGEO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        dr = data.Listar_Regiones(cn);
        while (dr.Read())
        {
            BE_UBIGEO i = new BE_UBIGEO();
            i.UBIREGION = dr.Text("UBIREGION");
            i.TXREGION = dr.Text("REGION");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_UBIGEO> Listar_Provincias(BE_UBIGEO c)
    {
        List<BE_UBIGEO> r = new List<BE_UBIGEO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        dr = data.Listar_Provincias(cn, c);
        while (dr.Read())
        {
            BE_UBIGEO i = new BE_UBIGEO();
            i.UBIPROVINCIA = dr.Text("UBIPROVINCIA");
            i.TXPROVINCIA = dr.Text("PROVINCIA");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_UBIGEO> Listar_Distritos(BE_UBIGEO c)
    {
        List<BE_UBIGEO> r = new List<BE_UBIGEO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Distritos(cn, c);
        while (dr.Read())
        {
            BE_UBIGEO i = new BE_UBIGEO();
            i.UBIDISTRITO = dr.Text("UBIDISTRITO");
            i.TXDISTRITO = dr.Text("DISTRITO");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_UBIGEO> Listar_Distritos_sin_capitales(BE_UBIGEO BE_Ubig)
    {
        List<BE_UBIGEO> r = new List<BE_UBIGEO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
            dr = data.Listar_Distritos_sin_capitales(cn, BE_Ubig);
            while (dr.Read())
            {
                BE_UBIGEO i = new BE_UBIGEO();


                i.UBIDISTRITO = dr.Text("UBIDISTRITO");
                i.TXDISTRITO = dr.Text("DISTRITO");

                r.Add(i);
            }
        pCerrarDr(cn, dr);
        return r;       
    }

    public List<BE_UBIGEO> Listar_Regiones_JEE(BE_UBIGEO BE_Ubig)
    {
        List<BE_UBIGEO> r = new List<BE_UBIGEO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
            dr = data.Listar_Regiones_JEE(cn, BE_Ubig);
            while (dr.Read())
            {
                BE_UBIGEO i = new BE_UBIGEO();

                i.UBIREGION = dr.Text("ID_REGION");
                i.TXREGION = dr.Text("REGION");

                r.Add(i);
            }
            pCerrarDr(cn, dr);
            return r;       
    }

    public List<BE_UBIGEO> Listar_Provincias_JEE(BE_UBIGEO BE_Ubig)
    {
        List<BE_UBIGEO> r = new List<BE_UBIGEO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;

        dr = data.Listar_Provincias_JEE(cn, BE_Ubig);
        while (dr.Read())
        {
            BE_UBIGEO i = new BE_UBIGEO();

            i.UBIPROVINCIA = dr.Text("ID_PROVINCIA");
            i.TXPROVINCIA = dr.Text("PROVINCIA");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_UBIGEO> Listar_Distritos_JEE(BE_UBIGEO BE_Ubig)
    {
        List<BE_UBIGEO> r = new List<BE_UBIGEO>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        dr = data.Listar_Distritos_JEE(cn, BE_Ubig);
        while (dr.Read())
        {
            BE_UBIGEO i = new BE_UBIGEO();

            i.UBIDISTRITO = dr.Text("ID_DISTRITO");
            i.TXDISTRITO = dr.Text("DISTRITO");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }


    public BE_UBIGEO Desc_Ubigeo(string strUbigeo)
    {
        BE_UBIGEO i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        dr = data.Desc_Ubigeo(cn, strUbigeo);
        if (dr.Read())
        {
            i = new BE_UBIGEO();
            i.UBIREGION = dr.Text("ubiregion");
            i.UBIPROVINCIA = dr.Text("ubiprovincia");
            i.UBIDISTRITO = dr.Text("ubidistrito");

            i.TXREGION = dr.Text("region");
            i.TXPROVINCIA = dr.Text("provincia");
            i.TXDISTRITO = dr.Text("distrito");

        }
        pCerrarDr(cn, dr);
        return i;
    }

    public string Get_Ubigeo(Int16 ubiRegion, Int16 ubiProv, Int16 ubiDist)
    {
        return data.Get_Ubigeo(ubiRegion, ubiProv, ubiDist);
    }

    public BL_Ubigeo() { data = new DA_Ubigeo(); }
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

