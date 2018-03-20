using System;
using System.Data;
using Oracle.DataAccess.Client;
	public class DA_CargosOP : DA_BASE
	{

		public OracleDataReader Listar_CargosOP(OracleConnection CN, BE_CargosOP oBE)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = oBE.Cod_OP;

				ARRPARAM[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = oBE.orden;

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_cargos.sp_cargos_op_grid", ARRPARAM);
			
				
		}


		public string Actualizar(BE_CargosOP oBE)
		{
			OracleParameter[] arrParam = new OracleParameter[7];


			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_cargo", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = oBE.Cod_Cargo;

				arrParam[2] = new OracleParameter("i_anos_vigencia", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[2].Value = oBE.anos_vigencia;

				arrParam[3] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
				arrParam[3].Value = oBE.cod_tipo_doc;

				arrParam[4] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = oBE.orden;

				arrParam[5] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[5].Value = Yoo.UserId;

            arrParam[6] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[6].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_cargos.sp_cargos_op_update", arrParam);

				return Convert.ToString(arrParam[6].Value.ToString());

			
		}


		public int Agregar(BE_CargosOP oBE)
		{
			OracleParameter[] arrParam = new OracleParameter[7];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_cargo", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = oBE.Cod_Cargo;

				arrParam[2] = new OracleParameter("i_anos_vigencia", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[2].Value = oBE.anos_vigencia;

				arrParam[3] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
				arrParam[3].Value = oBE.cod_tipo_doc;

				arrParam[4] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = oBE.orden;

				arrParam[5] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[5].Value = Yoo.UserId;

            arrParam[6] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[6].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_cargos.sp_cargos_op_insert", arrParam);

				return Convert.ToInt32(arrParam[6].Value.ToString());
            
		}
	}

