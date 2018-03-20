using System.Data;
using Oracle.DataAccess.Client;

	public class DA_Persona : DA_BASE
	{

		public OracleDataReader Obtener_Persona(OracleConnection CN, string Cod_Dni)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = Cod_Dni;

				ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_DNI_sel", ARRPARAM);
			
		}

		public OracleDataReader Obtener_Personas_x_Nombres_Completo(OracleConnection CN, BE_Persona oBE)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[4];

			
				ARRPARAM[0] = new OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = oBE.ApePat;
				ARRPARAM[1] = new OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[1].Value = oBE.ApeMat;
				ARRPARAM[2] = new OracleParameter("i_nombre", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[2].Value = oBE.Nombre;

				ARRPARAM[3] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ApPatApMatNombres_grid", ARRPARAM);
			
		}

		public OracleDataReader Obtener_Personas_x_ApPat_Nombres(OracleConnection CN, BE_Persona oBE)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[4];

			
				ARRPARAM[0] = new OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = oBE.ApePat;
				ARRPARAM[1] = new OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[1].Value = oBE.ApeMat;
				ARRPARAM[2] = new OracleParameter("i_nombre", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[2].Value = oBE.Nombre;

				ARRPARAM[3] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ApPatNombres_grid", ARRPARAM);
			
		}

		public OracleDataReader Obtener_Personas_x_ApPat_ApMat(OracleConnection CN, BE_Persona oBE)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[4];

			
				ARRPARAM[0] = new OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = oBE.ApePat;
				ARRPARAM[1] = new OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[1].Value = oBE.ApeMat;
				ARRPARAM[2] = new OracleParameter("i_nombre", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[2].Value = oBE.Nombre;

				ARRPARAM[3] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);


				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ApPatApMat_grid", ARRPARAM);
			
		}

		public OracleDataReader Obtener_Personas_x_ApMat_Nombres(OracleConnection CN, BE_Persona oBE)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[4];

			
				ARRPARAM[0] = new OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = oBE.ApePat;
				ARRPARAM[1] = new OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[1].Value = oBE.ApeMat;
				ARRPARAM[2] = new OracleParameter("i_nombre", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[2].Value = oBE.Nombre;

				ARRPARAM[3] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);


				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ApMatNombres_grid", ARRPARAM);
			
		}

	}

