using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;


public class BL_Alianza : BL_BASE
{
    private DA_Alianza data;
    public List<BE_Alianza> Lista_OPs_Alianza(BE_Alianza BE_List)
    {
        List<BE_Alianza> r = new List<BE_Alianza>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_OPs_Alianza(cn, BE_List);
        while (dr.Read())
        {
            BE_Alianza i = new BE_Alianza();
            i.cod_op_asoc = dr.Num("cod_op_asoc");
            i.des_op_asoc = dr.Text("des_op_asoc");
            i.Num_Resol_Alianza = dr.Text("Num_Resol_Alianza");
            i.Observ = dr.Text("Observ");
            i.FLASOCIADO = dr.Num("flg_Asociado");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_Alianza> Listar_Proceso_Electoral()
    {
        List<BE_Alianza> r = new List<BE_Alianza>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Proceso_Electoral(cn);
        while (dr.Read())
        {
            BE_Alianza i = new BE_Alianza();

            i.IDProcesoElec = dr.Text("IDProceso");
            i.TXProcesoElec = dr.Text("TXProceso");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_Alianza> Listar_Tipo_Elecc()
    {
        List<BE_Alianza> r = new List<BE_Alianza>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Tipo_Elecc(cn);
        while (dr.Read())
        {
            BE_Alianza i = new BE_Alianza();
            i.Cod_Tipo_Elecc = dr.Text("Cod_Tipo_Elecc");
            i.Des_Tipo_Elecc = dr.Text("Des_Tipo_Elecc");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_Alianza> Listar_Tipo_Elecc_02(string cod_tipo_elecc)
    {
        List<BE_Alianza> r = new List<BE_Alianza>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Tipo_Elecc_02(cn, cod_tipo_elecc);

        while (dr.Read())
        {
            BE_Alianza i = new BE_Alianza();

            i.Cod_Tipo_Elecc = dr.Text("Cod_Tipo_Elecc");
            i.Des_Tipo_Elecc = dr.Text("Des_Tipo_Elecc");

            i.EnableDdlReg = bool.Parse(dr.Text("EnableDdlReg"));
            i.EnableDdlProv = bool.Parse(dr.Text("EnableDdlProv"));
            i.EnableDdlDist = bool.Parse(dr.Text("EnableDdlDist"));
            i.Cod_Ente = dr.Text("Cod_Ente");


            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public int Delete_OP_Asoc(BE_Alianza oBE)
    {
        return data.Delete_OP_Asoc(oBE);
    }

    public int Adiciona_OP_Asoc(BE_Alianza oBE)
    {
        return data.Adiciona_OP_Asoc(oBE);
    }

    public int Update_OP_Asoc(BE_Alianza c)
    {
        return data.Update_OP_Asoc(c);
    }

    public DataTable Crear_DT_AlianzaElectoral(int cod_op)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Lst_AlianzaElectoral(cn, cod_op);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }

    public DataTable Crear_DT_AlianzasGrid(int cod_op)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Lst_AlianzasGrid(cn, cod_op);
        dt.Load(dr);

        pCerrarDr(cn, dr);
        return dt;
    }

    public DataTable Crear_DT_Alianzas_Listar()
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Lst_AlianzasListar(cn);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }

    //Public Function Crear_DT_AlianzasMiembros(ByVal cod_op As Integer) As DataTable
    //    Dim cn As New OracleConnection(TX_ESQUEMA)
    //    Dim dt As New DataTable
    //    Dim dr As OracleDataReader = Nothing
    //    Dim oDA As New DA_Alianza
    //    Try

    //        dr = oDA.Lst_AlianzasMiembros(cn, cod_op)

    //        dt.Load(dr)
    //    Catch ex As Exception
    //        Throw ex
    //    Finally
    //        pCerrarDr(cn, dr)
    //    End Try
    //    Return dt
    //End Function

    public DataTable Crear_DT_AlianzasTipoElecc(int cod_op)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Lst_AlianzasTipoElecc(cn, cod_op);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }

    public DataTable Crear_DT_AlianzasUbigeo(int cod_op, string cod_tipo_elecc)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Lst_AlianzasUbigeo(cn, cod_op, cod_tipo_elecc);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }

    public DataTable Crear_DT_AlianzasOP(BE_Alianza c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Lst_AlianzasOP(cn, c);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }

    public BL_Alianza() { data = new DA_Alianza(); }
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

