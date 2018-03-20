using System;
using System.Data;
using Oracle.DataAccess.Client;

	public class DA_Cargos_AltasBajas : DA_BASE
	{

		#region "Procedimientos de transaccion"



		public string Agregar(BE_Cargos_AltasBajas c)
		{
			OracleParameter[] arrParam = new OracleParameter[9];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value =  c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_correl", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value =  c.Cod_Correl_Repres;

				arrParam[2] = new OracleParameter("i_fec_carga", OracleDbType.Date, ParameterDirection.Input);
				arrParam[2].Value = c.Fec_Carga;

				arrParam[3] = new OracleParameter("i_num_asiento_carga", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[3].Value = c.Num_Asiento_Carga;

				arrParam[4] = new OracleParameter("i_fec_baja", OracleDbType.Date, ParameterDirection.Input);
				arrParam[4].Value = c.Fec_Baja;

				arrParam[5] = new OracleParameter("i_cod_motivo_baja", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[5].Value = c.Cod_Motivo_Baja;

				arrParam[6] = new OracleParameter("i_num_asiento_baja", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[6].Value = c.Num_Asiento_Baja;

				arrParam[7] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[7].Value = Yoo.UserId;

            arrParam[8] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[8].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_cargos.sp_cargos_insert", arrParam);

				return Convert.ToString(arrParam[8].Value.ToString());
            
		}

		public string Eliminar( BE_Cargos_AltasBajas oBE)
		{
			OracleParameter[] arrParam = new OracleParameter[5];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_correl", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = oBE.Cod_Correl_Repres;

				arrParam[2] = new OracleParameter("i_id_orden", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[2].Value = oBE.Id_Orden;

				arrParam[3] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = Yoo.UserId;

            arrParam[4] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[4].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_cargos.sp_cargos_delete", arrParam);

				return Convert.ToString(arrParam[4].Value.ToString());
            
		}

		public string Actualizar(BE_Cargos_AltasBajas oBE)
		{
			OracleParameter[] arrParam = new OracleParameter[10];


			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_correl", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = oBE.Cod_Correl_Repres;

				arrParam[2] = new OracleParameter("i_id_orden", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[2].Value = oBE.Id_Orden;

				arrParam[3] = new OracleParameter("i_fec_carga", OracleDbType.Date, ParameterDirection.Input);
				arrParam[3].Value = oBE.Fec_Carga;

				arrParam[4] = new OracleParameter("i_num_asiento_carga", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = oBE.Num_Asiento_Carga;

				arrParam[5] = new OracleParameter("i_fec_baja", OracleDbType.Date, ParameterDirection.Input);
				arrParam[5].Value = oBE.Fec_Baja;

				arrParam[6] = new OracleParameter("i_cod_motivo_baja", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[6].Value = oBE.Cod_Motivo_Baja;

				arrParam[7] = new OracleParameter("i_num_asiento_baja", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[7].Value = oBE.Num_Asiento_Baja;

				arrParam[8] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[8].Value = Yoo.UserId;

            arrParam[9] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[9].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_cargos.sp_cargos_update", arrParam);

				return Convert.ToString(arrParam[9].Value.ToString());

			
		}


        public string Set_Fecha_Inicio_Cargo(BE_Cargos_AltasBajas c)
        {
            OracleParameter[] arrParam = new OracleParameter[4];


            arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            arrParam[0].Value = c.Cod_OP;

            arrParam[1] = new OracleParameter("i_fec_carga", OracleDbType.Date, ParameterDirection.Input);
            arrParam[1].Value = c.Fec_Carga;

            arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[2].Value = Yoo.UserId;

            arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

            ORACLEHELPER.EjecutarQR("pkg_cargos.sp_fecha_inicio_cargo", arrParam);

            return Convert.ToString(arrParam[3].Value.ToString());

        }

		#endregion

		#region "Procedimientos de consulta"


		public OracleDataReader Get_Directivo_Cargo(OracleConnection CN, BE_Cargos_AltasBajas c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("i_correl", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Cod_Correl_Repres;

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_cargos.sp_cargos_directivo_sel", ARRPARAM);
			
		}


		public OracleDataReader Listar_AltasBajas_Cargo(OracleConnection CN, BE_Cargos_AltasBajas c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[4];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Cod_DNI;

				ARRPARAM[2] = new OracleParameter("i_cod_cargo", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[2].Value = c.Cod_Cargo;

				ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_cargos.sp_cargos_grid", ARRPARAM);
			
		}


		#endregion
	}

