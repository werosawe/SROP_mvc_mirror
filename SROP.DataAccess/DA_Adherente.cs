using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


	public class DA_Adherente : DA_BASE
	{

		#region "Procedimientos de consulta"

		public OracleDataReader Listar_Adherentes(OracleConnection CN, Int32 Cod_OP)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = Cod_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_firmas_adh_grid", ARRPARAM);
		}

        public OracleDataReader Listar_DatosAdherentes(OracleConnection cn, BE_Adherente c)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[3];

            ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[0].Value = c.Cod_OP;
            ARRPARAM[1] = new OracleParameter("i_cod_req", OracleDbType.Char, ParameterDirection.Input);
            ARRPARAM[1].Value = c.Cod_Req;
            ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_firmas_adh_sel", ARRPARAM);
        }
		#endregion

		#region "Procedimientos de transaccion"

		public int Agregar(OracleConnection cn, BE_Adherente c)
		{
			OracleParameter[] arrParam = new OracleParameter[6];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_num_firmas_val", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Num_Firmas_Val;

				arrParam[2] = new OracleParameter("i_doc_onpe", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = c.Doc_Onpe;

				arrParam[3] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
				arrParam[3].Value = c.Fec_Doc;

				arrParam[4] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = Yoo.UserId;

            arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
				
				ORACLEHELPER.EjecutarQR("pkg_requisitos.sp_insert_firmas_adh", arrParam);

				return (int)arrParam[5].Value;

			
				
			
		}

		public int Actualizar(OracleConnection cn, BE_Adherente c)
		{
			OracleParameter[] arrParam = new OracleParameter[6];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_req", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = c.Cod_Req;

				arrParam[2] = new OracleParameter("i_flg_cumple", OracleDbType.Byte, ParameterDirection.Input);
				arrParam[2].Value = c.FLCUMPLE;

				arrParam[3] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = c.Observ;

				arrParam[4] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = Yoo.UserId;

            arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[5].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_requisitos.sp_update_req_02", arrParam);

				return (int)arrParam[5].Value;

			
		}

		public int Eliminar(OracleConnection cn, BE_Adherente c)
		{
			OracleParameter[] arrParam = new OracleParameter[4];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_doc_onpe", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = c.Doc_Onpe;

				arrParam[2] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
				arrParam[2].Value = c.Fec_Doc;

				arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
			
				ORACLEHELPER.EjecutarQR("pkg_requisitos.sp_delete_firmas_adh", arrParam);

				return (int)arrParam[3].Value;

			
				
			
		}
		#endregion

	}

