using System.Data;
using Oracle.DataAccess.Client;


	public class DA_Req_TipoOP : DA_BASE
	{

        public OracleDataReader Listar_RequisitoTipo_OP(OracleConnection cn, BE_ReqTipoOP c)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[2];
            ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.NChar, 2, ParameterDirection.Input);
            ARRPARAM[0].Value = c.Cod_Tipo_OP;
            ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_req_tipoOP_grid", ARRPARAM);
        }
	
	}

