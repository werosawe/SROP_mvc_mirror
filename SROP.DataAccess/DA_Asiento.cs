using System;
using System.Data;
using Oracle.DataAccess.Client;

public class DA_Asiento : DA_BASE
{

    

    public OracleDataReader Gets(OracleConnection cn, BE_Asiento c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_cod_tipo_asiento", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Cod_Tipo_Asiento;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_asientos_grid", ARRPARAM);
    }

    public OracleDataReader Get(OracleConnection cn, BE_Asiento c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_num_asiento", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Num_Asiento;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_Asientos_sel", ARRPARAM);
    }
 

   

    public int Agregar(BE_Asiento c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_num_asiento", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Num_Asiento;

        arrParam[2] = new OracleParameter("i_cod_tipo_asiento", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Tipo_Asiento;

        arrParam[3] = new OracleParameter("i_asiento", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Asiento;

        arrParam[4] = new OracleParameter("i_fec_asiento", OracleDbType.Date, ParameterDirection.Input);
        arrParam[4].Value = Convert.ToDateTime(c.Fec_Asiento);

        arrParam[5] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = c.Observ;

        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_insert_asientos", arrParam);

        return arrParam[7].Num();


    }

    public int Modificar(BE_Asiento c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_num_asiento", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Num_Asiento;

        arrParam[2] = new OracleParameter("i_cod_tipo_asiento", OracleDbType.Char, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Tipo_Asiento;

        arrParam[3] = new OracleParameter("i_asiento", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Asiento;

        arrParam[4] = new OracleParameter("i_fec_asiento", OracleDbType.Date, ParameterDirection.Input);
        arrParam[4].Value = Convert.ToDateTime(c.Fec_Asiento);

        arrParam[5] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = c.Observ;

        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_asientos", arrParam);

        return arrParam[7].Num();


    }

    public int Eliminar(BE_Asiento c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_num_asiento", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Num_Asiento;
        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_op.sp_delete_asientos", arrParam);
        return arrParam[2].Num();
    }

    public int Modificar_FechaCarga_Directivos( BE_Asiento c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_fec_asiento", OracleDbType.Date, ParameterDirection.Input);
        arrParam[1].Value = c.Fec_Asiento;

        arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = Yoo.UserId;

        arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_fechacarga_direc", arrParam);

        return arrParam[3].Num();


    }

    public BE_Asiento.ret_HistCargo Busca_Asiento_Historial_Cargos(OracleConnection cn, BE_Asiento c)
    {
        BE_Asiento.ret_HistCargo ret = default(BE_Asiento.ret_HistCargo);
        OracleParameter[] arrParam = new OracleParameter[6];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_num_asiento", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Num_Asiento;

        arrParam[2] = new OracleParameter("o_total_asientos", OracleDbType.Int32, ParameterDirection.Output);

        arrParam[3] = new OracleParameter("o_Cargo", OracleDbType.Varchar2, ParameterDirection.Output);
        arrParam[3].Size = 400;

        arrParam[4] = new OracleParameter("o_DNI", OracleDbType.Varchar2, ParameterDirection.Output);
        arrParam[4].Size = 8;

        arrParam[5] = new OracleParameter("o_Nombres", OracleDbType.Varchar2, ParameterDirection.Output);
        arrParam[5].Size = 400;

        ORACLEHELPER.EjecutarQR("pkg_op.sp_buscar_asiento_hist_cargos", arrParam);

        ret.Total_Asientos = (int)arrParam[2].Value;
        ret.Cargo = (string)arrParam[3].Value;
        ret.DNI = (string)arrParam[4].Value;
        ret.Nombres = (string)arrParam[5].Value;
        return ret;
    }

   

}

