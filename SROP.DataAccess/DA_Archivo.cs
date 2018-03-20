using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


	public class DA_Archivo : DA_BASE
	{

		#region "Procedimientos de consulta"

		public OracleDataReader Listar_Pendientes(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_archivo.sp_listar_op_sin_cod", ARRPARAM);
			
		}

        public OracleDataReader Obtener_Archivo(OracleConnection CN, Int32 Cod_OP)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[2];
            ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[0].Value = Cod_OP;
            ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(CN, "pkg_archivo.sp_listar_op_sel", ARRPARAM);
        }

        public DataTable Obtener_Caratula_Legajos(string CodTipoOP, Int32 Cod_OP)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[3];
            ARRPARAM[0] = new OracleParameter("i_codtipoop", OracleDbType.Char, ParameterDirection.Input);
            ARRPARAM[0].Value = CodTipoOP.Text();
            ARRPARAM[1] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[1].Value = Cod_OP;
            ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDT("pkg_archivo.sp_listar_carat_legajos", ARRPARAM);
        }

        public DataTable Obtener_Caratula_Planillones(string CodTipoOP, Int32 Cod_OP)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[3];
            ARRPARAM[0] = new OracleParameter("i_codtipoop", OracleDbType.Char, ParameterDirection.Input);
            ARRPARAM[0].Value = CodTipoOP;
            ARRPARAM[1] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[1].Value = Cod_OP;
            ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDT("pkg_archivo.sp_listar_carat_plani", ARRPARAM);
        }

        public DataTable Obtener_Caratula_Lomos(string CodTipoOP, Int32 Cod_OP)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[3];

            ARRPARAM[0] = new OracleParameter("i_codtipoop", OracleDbType.Char, ParameterDirection.Input);
            ARRPARAM[0].Value = CodTipoOP;
            ARRPARAM[1] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[1].Value = Cod_OP;
            ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDT("pkg_archivo.sp_listar_carat_legajos", ARRPARAM);
        }

        public DataTable Obtener_Caratula_Padrones(string CodTipoOP, Int32 Cod_OP)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[3];
            ARRPARAM[0] = new OracleParameter("i_codtipoop", OracleDbType.Char, ParameterDirection.Input);
            ARRPARAM[0].Value = CodTipoOP;
            ARRPARAM[1] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[1].Value = Cod_OP;
            ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDT("pkg_archivo.sp_listar_carat_padron", ARRPARAM);
        }

		#endregion

		#region "Procedimientos de transaccion"

		public int Modificar(BE_Archivo c)
		{
			OracleParameter[] arrParam = new OracleParameter[7];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_arc", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Cod_Arc;

				arrParam[2] = new OracleParameter("i_tx_ubic_arc", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = c.Tx_Ubic_Arc;

				arrParam[3] = new OracleParameter("i_num_tom_leg", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[3].Value = c.Num_Tom_Leg;

				arrParam[4] = new OracleParameter("i_num_tom_pla", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = c.Num_Tom_Pla;

				arrParam[5] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[5].Value = Yoo.UserId;

            arrParam[6] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
			

				ORACLEHELPER.EjecutarQR("pkg_archivo.sp_update_arc", arrParam);

				return Convert.ToInt32(arrParam[6].Value.ToString());
            
		}
		#endregion

	}

