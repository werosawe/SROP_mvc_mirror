using System.Data;
using Oracle.DataAccess.Client;

public class DA_PadronAfil : DA_BASE
{

    public OracleDataReader Listar_Padrones(OracleConnection CN, BE_PadronAfil BE)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Int32, 2, ParameterDirection.Input);
        ARRPARAM[0].Value = BE.Cod_Tipo_OP;

        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_op_padrones", ARRPARAM);

    }

    public OracleDataReader Get_Datos_Ultimo_Padron(OracleConnection CN, int Cod_OP)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, 2, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_afiliados.sp_get_datos_Ultimo_padron", ARRPARAM);


    }

    public OracleDataReader Listar_Padrones_Partes(OracleConnection CN, int Cod_OP)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, 2, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_afiliados.sp_listar_padron_partes", ARRPARAM);

    }

}

