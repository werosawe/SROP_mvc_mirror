using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Web.Mvc;

public class BL_TipoOP : BL_BASE
{

    private DA_TipoOP data;

    //Algoritmo
    //TipoOP afecta Ambito
    //Ambito afecta Region Prov Distrito

    //Crea lista_tipoOP

    //Loop lista_tipoOP
    //   IF lista_tipoOP.Valor = ComboTipoOP.Valor
    //   entonces
    //         ComboAmbito.SelectedValue = lista_tipoOP.CodAmbito
    //         ComboLibro.SelectedValue = lista_tipoOP.CodLibro
    //         ComboRegion.Enabled = lista_tipoOP.ValorBooleanParaRegion
    //         ComboProvincia.Enabled = lista_tipoOP.ValorBooleanParaProv
    //         ComboDistrito.Enabled = lista_tipoOP.ValorBooleanParaDist
    //   end if
    //end loop

    public BE_TipoOP.EstadoDeCombos_ExpOP getEstadosDeCombos(string Cod_Tipo_OP_)
    {
        BE_TipoOP.EstadoDeCombos_ExpOP functionReturnValue = default(BE_TipoOP.EstadoDeCombos_ExpOP);
        List<BE_TipoOP> r = Gets();
        functionReturnValue.ComboAmbito_SelectedIndex = 0;
        functionReturnValue.ComboAmbitoIsEnabled = false;
        functionReturnValue.ComboLibro_SelectedIndex = 0;
        functionReturnValue.ComboRegionIsEnabled = false;
        functionReturnValue.ComboProvinciaIsEnabled = false;
        functionReturnValue.ComboDistritoIsEnabled = false;
        foreach (BE_TipoOP item in r)
        {
            if (item.Cod_Tipo_OP == Cod_Tipo_OP_)
            {
                functionReturnValue.ComboAmbito_SelectedIndex = item.COD_AMBITO.Num();
                functionReturnValue.ComboAmbitoIsEnabled = bool.Parse(item.ENABLE_DDL_AMB);
                functionReturnValue.ComboLibro_SelectedIndex = item.COD_TIPO_LIBRO.Num();
                functionReturnValue.ComboRegionIsEnabled = bool.Parse(item.ENABLE_DDL_REG);
                functionReturnValue.ComboProvinciaIsEnabled = bool.Parse(item.ENABLE_DDL_PROV);
                functionReturnValue.ComboDistritoIsEnabled = bool.Parse(item.ENABLE_DDL_DIST);

            }
        }
        return functionReturnValue;
    }



    public List<SelectListItem> GetsTipoOrganizacionPolitica()
    {
        List<SelectListItem> r = new List<SelectListItem>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Gets(cn);
        while (dr.Read())
        {
            SelectListItem item = new SelectListItem();
            item.Value = dr.Text("COD_TIPO_OP");
            item.Text = dr.Text("DES_TIPO_OP");
            r.Add(item);
        }
        pCerrarDr(cn, dr);
        return r;
    }
    
    public BE_TipoOP Get(BE_TipoOP c)
    {
        BE_TipoOP i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Get(cn,c);
            if (dr.Read())
            {
                i = new BE_TipoOP();
                i.Cod_Tipo_OP = dr.Text("COD_TIPO_OP");
                i.DES_TIPO_OP = dr.Text("DES_TIPO_OP");
                i.COD_AMBITO = dr.Text("COD_AMBITO");
                i.COD_TIPO_LIBRO = dr.Text("COD_TIPO_LIBRO");
                i.ENABLE_DDL_AMB = dr.Text("ENABLEDDLAMB");
                i.ENABLE_DDL_REG = dr.Text("ENABLEDDLREG");
                i.ENABLE_DDL_PROV = dr.Text("ENABLEDDLPROV");
                i.ENABLE_DDL_DIST = dr.Text("ENABLEDDLDIST");
                i.FLSIMBOLO = dr.Num("FLG_SIMBOLO");
            }
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_TipoOP> Gets()
    {
        List<BE_TipoOP> r = new List<BE_TipoOP>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn);
            while (dr.Read())
            {
                BE_TipoOP i = new BE_TipoOP();
                i.Cod_Tipo_OP = dr.Text("COD_TIPO_OP");
                i.DES_TIPO_OP = dr.Text("DES_TIPO_OP");
                i.COD_AMBITO = dr.Text("COD_AMBITO");
                i.COD_TIPO_LIBRO = dr.Text("COD_TIPO_LIBRO");
                i.ENABLE_DDL_AMB = dr.Text("ENABLEDDLAMB");
                i.ENABLE_DDL_REG = dr.Text("ENABLEDDLREG");
                i.ENABLE_DDL_PROV = dr.Text("ENABLEDDLPROV");
                i.ENABLE_DDL_DIST = dr.Text("ENABLEDDLDIST");
                i.FLSIMBOLO = dr.Num("FLG_SIMBOLO");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BL_TipoOP() { data = new DA_TipoOP(); }
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

