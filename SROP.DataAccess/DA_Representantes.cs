using System;
using System.Data;
using Oracle.DataAccess.Client;


public class DA_Representantes : DA_BASE
{

    public OracleDataReader Listar_Representantes(OracleConnection cn, BE_Representantes c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, 4, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_repres.sp_listar_rep", ARRPARAM);
    }

    public OracleDataReader Listar_Personeros(OracleConnection cn, BE_Representantes c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, 4, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_repres.sp_listar_personeros", ARRPARAM);
    }

    public OracleDataReader Listar_Cargos_Repres(OracleConnection cn, BE_Representantes c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, 4, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_repres.sp_listar_cargos_repres", ARRPARAM);
    }

    public DataTable Listar_Repres_x_Cargos(BE_Representantes c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, 4, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("I_COD_cargo", OracleDbType.NVarchar2, 200, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Cod_Cargo;
        ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDT("pkg_repres.sp_listar_repres_x_cargo", ARRPARAM);
    }
}

