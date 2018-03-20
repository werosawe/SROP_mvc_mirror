using System.Data;
using Oracle.DataAccess.Client;


	public class DA_DocLegales : DA_BASE
	{

		public OracleDataReader Listar_DocLeg_Cab(OracleConnection CN, BE_DocLegales c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_doclegales_cab_grid", ARRPARAM);
			
		}

		public DataTable Listar_DocLeg_Det(BE_DocLegales c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_param", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Pri;
				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDT("pkg_listar.sp_doclegales_det_grid", ARRPARAM);
			
				
		}

		public OracleDataReader Listar_DocLeg(OracleConnection CN, BE_DocLegales c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_tipo_lista", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.tipo_lista;

				ARRPARAM[1] = new OracleParameter("i_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[1].Value = c.tipo_doc;

				ARRPARAM[2] = new OracleParameter("i_para1", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[2].Value = c.Cod_Pri;

				ARRPARAM[3] = new OracleParameter("i_para2", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[3].Value = "00";

				ARRPARAM[4] = new OracleParameter("i_para3", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[4].Value = "00";

				ARRPARAM[5] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_doclegales_listar", ARRPARAM);

			
		}



	}

