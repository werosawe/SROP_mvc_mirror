using System.Data;
using Oracle.DataAccess.Client;
	public class DA_Reportes : DA_BASE
	{


		public OracleDataReader Lst_Partidos(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Rep_OP_02", ARRPARAM);

			
		}

		public OracleDataReader Lst_MovReg(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Rep_OP_Ubigeo", ARRPARAM);
            
		}

		public OracleDataReader Lst_OPLP(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Rep_OP_Ubigeo", ARRPARAM);

			
		}

		public OracleDataReader Lst_OPLD(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Rep_OP_Ubigeo", ARRPARAM);

			
		}

		public OracleDataReader Lst_Alianzas(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Rep_Alianzas", ARRPARAM);
            
		}

		public OracleDataReader Lst_Resoluciones(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = "01";

				ARRPARAM[1] = new OracleParameter("i_groupxuser", OracleDbType.Int16, ParameterDirection.Input);
				ARRPARAM[1].Value = (c.boResolAgrup ? 1 : 0);

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_docums_ops", ARRPARAM);
            
		}

		public OracleDataReader Lst_Personeros_Direcc(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = "00";

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_direcc_personeros", ARRPARAM);

			
		}

		public OracleDataReader Lst_Directivos_Vencidos(OracleConnection CN, BE_Reportes c)
		{

			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_op_repres_vencidos", ARRPARAM);
			
				

		}

		public OracleDataReader Lst_Directivos_Por_Vencer(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_op_repres_por_vencer", ARRPARAM);
			
				
		}

		public OracleDataReader Lst_OP_Registradas(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_LISTAR_OP_05", ARRPARAM);

			
		}

		public OracleDataReader Lst_OP_x_insc_pend_final(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_listar_op_x_insc_pend_final", ARRPARAM);

			
		}

		public OracleDataReader Lst_OP_Detalle_insc_pend_final(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_x_det_insc_pend_fin", ARRPARAM);
            
		}

		public OracleDataReader Lst_Consol_PadronAfil(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = "01";


				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_LISTAR_CONSOL_PADRON_AFIL", ARRPARAM);
            
		}

		public OracleDataReader Lst_Constancias(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_constancias", ARRPARAM);
            
		}

		public OracleDataReader Lst_Exp_Asignados(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_asistente_x_op", ARRPARAM);
            
		}

		public OracleDataReader Lst_Tareas_Pend_x_OP(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_tareas_pend_x_op", ARRPARAM);
            
		}

		public OracleDataReader Lst_Tareas_Pend_x_Tarea(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_tareas_pend_x_tarea", ARRPARAM);
            
		}

		public OracleDataReader Lst_Comites_Afil(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[6];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Nro_Entrega;
				ARRPARAM[2] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[2].Value = c.ubireg;
				ARRPARAM[3] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[3].Value = c.ubiprov;
				ARRPARAM[4] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[4].Value = c.ubidist;
				ARRPARAM[5] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				//Orden Original
				if (c.Orden_ComAfil == "01") {
					return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Listar_Comites_Afil_1", ARRPARAM);
				} else {
					return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Listar_Comites_Afil_2", ARRPARAM);
				}
                
		}

		public OracleDataReader Lst_Comites(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Nro_Entrega;
				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Listar_Comites", ARRPARAM);
            
		}

		public OracleDataReader Lst_Comites_Consolidado(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("i_str_entregas", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[1].Value = c.str_entregas;
				// "2,3"

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.SP_Listar_Comites_uniq", ARRPARAM);
            
		}

		public OracleDataReader Lst_Comites_Uniq(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[5];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("i_ubiregion", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.ubireg;
				ARRPARAM[2] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[2].Value = c.ubiprov;
				ARRPARAM[3] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[3].Value = c.ubidist;
				ARRPARAM[4] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_listar_comites_afil_x_ubi", ARRPARAM);
            
		}

		public OracleDataReader Lst_Comites_Revisar_VF(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("i_str_entregas", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[1].Value = c.str_entregas;
				// "2,3"

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.SP_Listar_Comites_Revisar_VF", ARRPARAM);
            
		}

		public OracleDataReader Lst_Directivos(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

				if (c.Activos_Bajas_Directivos == 0) {
					//Solo Directivos actuales
					return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_REP_PERSONEROS_1", ARRPARAM);

				//Actuales + Dados baja
				} else if (c.Activos_Bajas_Directivos == 1) {
					//Actuales + Dados baja
					return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_REP_PERSONEROS_2", ARRPARAM);

				} else if (c.Activos_Bajas_Directivos == 2) {
					// Directivos con Vigencia Mayor a 4 anos
					ARRPARAM = new OracleParameter[3];
					ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
					ARRPARAM[0].Value = c.Cod_OP;
					ARRPARAM[1] = new OracleParameter("i_anos_vigencia_cargo", OracleDbType.Int32, ParameterDirection.Input);
					ARRPARAM[1].Value = c.anos_vigencia_cargo;
					ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
					return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_REP_PERSONEROS_3", ARRPARAM);

				} else if (c.Activos_Bajas_Directivos == 3) {
					// Directivos con Vigencia Menor a 4 anos
					ARRPARAM = new OracleParameter[3];
					ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
					ARRPARAM[0].Value = c.Cod_OP;
					ARRPARAM[1] = new OracleParameter("i_anos_vigencia_cargo", OracleDbType.Int32, ParameterDirection.Input);
					ARRPARAM[1].Value = c.anos_vigencia_cargo;
					ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
					return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_REP_PERSONEROS_4", ARRPARAM);

				} else if (c.Activos_Bajas_Directivos == 4) {
					// Directivos con Vigencia Cerca a 4 anos (a 1 mes de cumplir 4 anos)
					ARRPARAM = new OracleParameter[3];
					ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
					ARRPARAM[0].Value = c.Cod_OP;
					ARRPARAM[1] = new OracleParameter("i_anos_vigencia_cargo", OracleDbType.Int32, ParameterDirection.Input);
					ARRPARAM[1].Value = c.anos_vigencia_cargo;
					ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
					return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_REP_PERSONEROS_5", ARRPARAM);                                      
				}
                else
                {
                    return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_REP_PERSONEROS_1", ARRPARAM);
                }

			
				
		}

        public OracleDataReader Lst_Ult4anos(OracleConnection cn)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[2];

            ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
            ARRPARAM[0].Value = Yoo.UserId;
            ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            return ORACLEHELPER.ObtenerDR(cn, "pkg_Afiliados.sp_listar_consulta_detalle", ARRPARAM);
        }

		public OracleDataReader Lst_TodosUsers(OracleConnection CN, BE_Reportes c)
		{



			
				switch (c.filtro) {
					case -1:
						//Todos los usuarios
						OracleParameter[] ARRPARAM = new OracleParameter[1];

						ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);


						return ORACLEHELPER.ObtenerDR(CN, "pkg_Users.SP_REP_USERS", ARRPARAM);
					default:
						//Usuarios filtrados

						OracleParameter[] ARRPARAM_ = new OracleParameter[3];
						ARRPARAM_[0] = new OracleParameter("i_param", OracleDbType.Varchar2, ParameterDirection.Input);
						ARRPARAM_[0].Value = c.search;

						ARRPARAM_[1] = new OracleParameter("i_filtro", OracleDbType.Int16, ParameterDirection.Input);
						ARRPARAM_[1].Value = c.filtro;

						ARRPARAM_[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

						return ORACLEHELPER.ObtenerDR(CN, "pkg_Users.SP_Listar_Users_Search", ARRPARAM_);
				}
            
		}

		public OracleDataReader Lst_LoginsDetalle(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_fec_ini", OracleDbType.Date, ParameterDirection.Input);
				ARRPARAM[0].Value = c.FecIni;

				ARRPARAM[1] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
				ARRPARAM[1].Value = c.FecFin;

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Users.SP_LISTAR_LOGINS_01_b", ARRPARAM);

			
		}

		public OracleDataReader Lst_LoginsAgrupados(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_fec_ini", OracleDbType.Date, ParameterDirection.Input);
				ARRPARAM[0].Value = c.FecIni;

				ARRPARAM[1] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
				ARRPARAM[1].Value = c.FecFin;

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Users.SP_LISTAR_LOGINS_02_b", ARRPARAM);

			
		}

		public OracleDataReader Lst_ConstanciaOP(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Nro_ConstanciaOP;
				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_op.SP_Get_Constancia", ARRPARAM);

			
		}

		public OracleDataReader Lst_Libros(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_nro_libro", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_Libro;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.SP_Listar_Libros", ARRPARAM);
				//GenerarRpt("pkg_Insc_OP.SP_Listar_Libros", oRpt)
			
		}


		public OracleDataReader Lst_Indicador_A11_sum(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a11_sum", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_A11_det(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a11_det", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_A12_sum(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a12_sum", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_A12_det(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a12_det", ARRPARAM);

			
		}


		public OracleDataReader Lst_Indicador_A13_sum(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a13_sum", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_A13_det(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a13_det", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_A14_sum(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a14_sum", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_A14_det(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_a14_det", ARRPARAM);

			
				
		}

		public OracleDataReader Lst_Indicador_B1a(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_1a", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_B1b(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_1b", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_B2a(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_2a", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_B2b(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_2b", ARRPARAM);
            
		}

		public OracleDataReader Lst_Indicador_B3a(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_3a", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_B3b(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_3b", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_B3c(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_3c", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_B4(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_4", ARRPARAM);

			
		}

		public OracleDataReader Lst_Indicador_B5a(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_5a", ARRPARAM);
            
		}

		public OracleDataReader Lst_Indicador_B5b(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_Doc;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_5b", ARRPARAM);
            
		}

		public OracleDataReader Lst_Indicador_B5c(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_Tipo_Doc;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_indicador_5c", ARRPARAM);
            
		}

		public OracleDataReader Lst_Indicador_Pedidos(OracleConnection CN, BE_Reportes c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.indicador_tiempo_atencion_sum", ARRPARAM);
            
		}

	}

