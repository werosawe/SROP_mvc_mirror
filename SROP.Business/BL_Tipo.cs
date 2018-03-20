using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_Tipo : BL_BASE
{

    private DA_Tipo data;
    public BE_Tipo Get(BE_Tipo c)
    {
        BE_Tipo i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetsActivo(cn, c);
            if (dr.Read())
            {
                i = new BE_Tipo
                {
                    IDTIPO = dr.Num("IDTIPO"),
                    TXTIPO = dr.Text("TXTIPO"),
                    TXSIGLA = dr.Text("TXSIGLA"),
                    TXVALOR = dr.Text("TXVALOR"),
                    TXDESCRIPCION = dr.Text("TXDESCRIPCION"),
                    NUORDEN = dr.Num("NUORDEN")
                };
            }
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
       
    }
    public List<BE_Tipo> GetsActivo(BE_Tipo c)
    {
        List<BE_Tipo> r = new List<BE_Tipo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetsActivo(cn, c);
            while (dr.Read())
            {
                BE_Tipo i = new BE_Tipo
                {
                    IDTIPO = dr.Num("IDTIPO"),
                    TXTIPO = dr.Text("TXTIPO"),
                    TXSIGLA = dr.Text("TXSIGLA"),
                    TXVALOR = dr.Text("TXVALOR"),
                    TXDESCRIPCION = dr.Text("TXDESCRIPCION"),
                    NUORDEN = dr.Num("NUORDEN")
                };
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }
    //TipoLibro = 1,
    //TipoZona = 2,
    //TipoVia = 3,
    //TipoArchivo = 4
    public List<SelectListItem> GetsTipoLibro() { return GetsActivoSelect(new BE_Tipo { IDGRUPO =TIPOTABLA.TipoLibro}); }
    public List<SelectListItem> GetsTipoZona() { return GetsActivoSelect(new BE_Tipo { IDGRUPO = TIPOTABLA.TipoZona }); }
    public List<SelectListItem> GetsTipoVia() { return GetsActivoSelect(new BE_Tipo { IDGRUPO = TIPOTABLA.TipoVia }); }

    public List<SelectListItem> GetsActivoSelect(BE_Tipo c)
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetsActivo(cn, c);
            while (dr.Read())
            {
                SelectListItem item = new SelectListItem
                {
                    Value = dr.Text("IDTIPO"),
                    Text = dr.Text("TXTIPO")
                };
                r.Add(item);
            }     
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BL_Tipo() { data = new DA_Tipo(); }
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

