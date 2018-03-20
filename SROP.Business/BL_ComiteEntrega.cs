using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


public class BL_ComiteEntrega : BL_BASE
{

    private DA_ComiteEntrega data;

    public List<BE_ComiteEntrega> Listar_Entregas(int Cod_OP)
    {
        List<BE_ComiteEntrega> r = new List<BE_ComiteEntrega>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Entregas(cn, Cod_OP);

        while (dr.Read())
        {
            BE_ComiteEntrega i = new BE_ComiteEntrega();

            i.Cod_OP = dr.Num("Cod_Op");
            i.Cod_Tipo_OP = dr.Text("Cod_Tipo_Op");
            i.Nro_Entrega = dr.Num("Nro_Entrega");
            i.Afil_Val = dr.Num("Afil_Val");
            i.Afil_Present = dr.Num("Afil_Present");
            i.FLCUMPLE = dr.Num("Flg_Cumple");
            i.Fec_Envio_Reniec = dr.Fec("Fec_Envio_Reniec");
            i.Fec_From_Reniec = dr.Fec("Fec_From_Reniec");  
            i.UBIREGION = dr.Text("UbiRegion");
            i.UBIPROVINCIA = dr.Text("UbiProvincia");
            i.UBIDISTRITO = dr.Text("UbiDistrito");
            i.Fec_Solic = (dr["Fec_Solic"] == null ? null : dr.Text("Fec_Solic"));
            i.Observ = dr.Text("Observ");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public BE_ComiteEntrega Selecciona_Entrega(int Cod_OP, int nro_entrega)
    {
        BE_ComiteEntrega i = new BE_ComiteEntrega();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Selecciona_Entrega(cn, Cod_OP, nro_entrega);

        while (dr.Read())
        {

            i.Cod_OP = dr.Num("Cod_Op");
            i.Cod_Tipo_OP = dr.Text("Cod_Tipo_Op");
            i.Nro_Entrega = dr.Num("Nro_Entrega");
            i.Afil_Val = dr.Num("Afil_Val");
            i.Afil_Present = dr.Num("Afil_Present");
            i.FLCUMPLE = dr.Num("Flg_Cumple");

            i.Fec_Envio_Reniec = dr.Fec("Fec_Envio_Reniec"); 
            i.Fec_From_Reniec = dr.Fec("Fec_From_Reniec"); 
            i.UBIREGION = dr.Text("UbiRegion");
            i.UBIPROVINCIA = dr.Text("UbiProvincia");
            i.UBIDISTRITO = dr.Text("UbiDistrito");
            i.Fec_Solic = (dr["Fec_Solic"] == null ? null : dr.Text("Fec_Solic"));
            i.Fec_Carga = dr.Fec("Fec_Entrega");  
            i.Observ = dr.Text("observ");

        }
        pCerrarDr(cn, dr);
        return i;
    }

    public int Agregar(BE_ComiteEntrega c)
    {
        return data.Agregar(c);
    }

    public int Modificar(BE_ComiteEntrega c)
    {
        return data.Modificar(c);
    }

    public int Eliminar(BE_ComiteEntrega c)
    {
        return data.Eliminar(c);
    }


    public string Setea_Fecha_Comite(BE_ComiteEntrega oBE_ComiteEnt)
    {
        string functionReturnValue = null;
        if (oBE_ComiteEnt.Fec_Carga == null)
        {

            if (oBE_ComiteEnt.Nro_Entrega == 1)
            {
                functionReturnValue = Fecha_Comite_Entrega_1(oBE_ComiteEnt.Cod_OP);

            }
            else if (oBE_ComiteEnt.Nro_Entrega == 2)
            {
                functionReturnValue = Fecha_Comite_Entrega_2(oBE_ComiteEnt.Cod_OP);

            }
            else if (oBE_ComiteEnt.Nro_Entrega > 2)
            {
                functionReturnValue = Fecha_Comite_Entrega_3(oBE_ComiteEnt.Cod_OP);

            }
        }
        else
        {
            functionReturnValue = string.Format("{0:dd-MMM-yyyy}", oBE_ComiteEnt.Fec_Carga);
        }
        return functionReturnValue;
    }

    private string Fecha_Comite_Entrega_1(int Cod_OP)
    {
        string functionReturnValue = null;
        List<BE_Etapa> l_Etapas = new List<BE_Etapa>();
        BL_Etapa oBL_Etapa = new BL_Etapa();
        l_Etapas = oBL_Etapa.Gets(new BE_Etapa(Cod_OP));
        functionReturnValue = string.Format("{0:dd-MMM-yyyy}", DateTime.Today);
        foreach (BE_Etapa e_loopVariable in l_Etapas)
        {
            var e = e_loopVariable;
            if (e.Cod_Est_Insc == "02")
            {
                functionReturnValue = string.Format("{0:dd-MMM-yyyy}", e.Fec_Estado_Insc);
                break; // TODO: might not be correct. Was : Exit For
            }
        }
        return functionReturnValue;

    }

    private string Fecha_Comite_Entrega_2(int Cod_OP)
    {
        string functionReturnValue = null;
        List<BE_Etapa> l_Etapas = new List<BE_Etapa>();
        BL_Etapa oBL_Etapa = new BL_Etapa();
        l_Etapas = oBL_Etapa.Gets(new BE_Etapa(Cod_OP));
        functionReturnValue = string.Format("{0:dd-MMM-yyyy}", DateTime.Today);

        foreach (BE_Etapa e_loopVariable in l_Etapas)
        {
            var e = e_loopVariable;
            if (e.Cod_Est_Insc == "35")
            {
                functionReturnValue = string.Format("{0:dd-MMM-yyyy}", e.Fec_Estado_Insc);
            }
        }
        return functionReturnValue;

    }

    private string Fecha_Comite_Entrega_3(int Cod_OP)
    {
        string functionReturnValue = null;
        List<BE_Etapa> l_Etapas = new List<BE_Etapa>();
        BL_Etapa oBL_Etapa = new BL_Etapa();
        l_Etapas = oBL_Etapa.Gets(new BE_Etapa(Cod_OP));
        functionReturnValue = string.Format("{0:dd-MMM-yyyy}", DateTime.Today);
        foreach (BE_Etapa e_loopVariable in l_Etapas)
        {
            var e = e_loopVariable;
            if (e.Cod_Est_Insc == "46")
            {
                functionReturnValue = string.Format("{0:dd-MMM-yyyy}", e.Fec_Estado_Insc);
            }
        }
        return functionReturnValue;
    }


    public int Update_Carga_FIN(BE_ComiteEntrega c)
    {
        return data.Update_Carga_FIN(c);
    }

    public BL_ComiteEntrega() { data = new DA_ComiteEntrega(); }
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

