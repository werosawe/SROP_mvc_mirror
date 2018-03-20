using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


	public class DA_Afiliados : DA_BASE
	{

		public OracleDataReader Listar_Padron_Afil_1(OracleConnection CN, BE_Afiliados c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[4];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;
				ARRPARAM[1] = new OracleParameter("i_seqMin", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.SeqMin;
				ARRPARAM[2] = new OracleParameter("i_seqMax", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[2].Value = c.SeqMax;
				ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_Afiliados.sp_listar_padron_afil_1", ARRPARAM);
			
			
		}

		public OracleDataReader Get_Afiliacion(OracleConnection cn, BE_Afiliados c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];			
				ARRPARAM[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, 8, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_DNI;
				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(cn, "pkg_Afiliados.sp_get_afiliado", ARRPARAM);
		}

		public OracleDataReader Get_Afiliacion_DNI_OP(OracleConnection cn, BE_Afiliados c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[4];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, 4, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("i_cod_proc", OracleDbType.Char, 2, ParameterDirection.Input);
				ARRPARAM[1].Value = "00";

				ARRPARAM[2] = new OracleParameter("i_cod_dni", OracleDbType.Char, 8, ParameterDirection.Input);
				ARRPARAM[2].Value = c.Cod_DNI;

				ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(cn, "PKG_AFILIADOS.sp_get_afiliado_op", ARRPARAM);
			
				
			
		}

    public int Mostrar_Registro_Afil(BE_Afiliados c)
    {
        OracleParameter[] pr = new OracleParameter[6];
        pr[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
        pr[1].Value = c.Cod_DNI;
        pr[2] = new OracleParameter("i_estado_afil", OracleDbType.Int16, ParameterDirection.Input);
        pr[2].Value = c.FLESTADOAFILIACION;
        pr[3] = new OracleParameter("i_cod_rol", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[3].Value = Yoo.Cod_Rol;
        pr[4] = new OracleParameter("o_mensaje", OracleDbType.Varchar2, ParameterDirection.Output);
        pr[4].Size = 400;
        pr[5] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("PKG_CRITERIO_AFIL.sp_mostrar_registro_afil", pr);
        c.MensajeAmostrar = (string)pr[4].Value;
        return (int)pr[5].Value;

    }


		public int Mostrar_Registro_Afil_Const(int Cod_OP, string Cod_DNI, int flg_estado_afil, string Cod_Rol, ref string MensajeAmostrar)
		{

			OracleParameter[] arrParam = new OracleParameter[6];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
				arrParam[1].Value = Cod_DNI;

				arrParam[2] = new OracleParameter("i_estado_afil", OracleDbType.Int16, ParameterDirection.Input);
				arrParam[2].Value = flg_estado_afil;

				arrParam[3] = new OracleParameter("i_cod_rol", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = Cod_Rol;

				arrParam[4] = new OracleParameter("o_mensaje", OracleDbType.Varchar2, ParameterDirection.Output);
				arrParam[4].Size = 400;
		
				arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
			
				ORACLEHELPER.EjecutarQR("PKG_AFILIADOS.sp_mostrar_registro_afil_const", arrParam);

				MensajeAmostrar = (string) arrParam[4].Value;

				return (int)arrParam[5].Value;

			
			
		}

        public string Comite_Name(int i_ubireg, int i_ubiprov, int i_ubidist)
        {
            OracleParameter[] arrParam = new OracleParameter[4];
            arrParam[0] = new OracleParameter("i_ubireg", OracleDbType.Int16, ParameterDirection.Input);
            arrParam[0].Value = i_ubireg;
            arrParam[1] = new OracleParameter("i_ubiprov", OracleDbType.Int16, ParameterDirection.Input);
            arrParam[1].Value = i_ubiprov;
            arrParam[2] = new OracleParameter("i_ubidist", OracleDbType.Int16, ParameterDirection.Input);
            arrParam[2].Value = i_ubidist;
            arrParam[3] = new OracleParameter("o_mensaje", OracleDbType.Varchar2, ParameterDirection.Output);
            arrParam[3].Size = 100;
            ORACLEHELPER.EjecutarQR("PKG_comites.sp_get_ubigeo", arrParam);
            return arrParam[3].Value.Text();
        }

        public OracleDataReader Busca_Afiliado_Por_DNI(OracleConnection cn, string Cod_DNI)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[2];
            ARRPARAM[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, 8, ParameterDirection.Input);
            ARRPARAM[0].Value = Cod_DNI;
            ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(cn, "pkg_Afiliados.sp_listar_apellidos_afiliado", ARRPARAM);
        }

        public OracleDataReader Listar_PeriodosAfilAnt(OracleConnection cn, BE_Afiliados c)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[3];
            ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, 4, ParameterDirection.Input);
            ARRPARAM[0].Value = c.Cod_OP;
            ARRPARAM[1] = new OracleParameter("i_cod_dni", OracleDbType.Char, 8, ParameterDirection.Input);
            ARRPARAM[1].Value = c.Cod_DNI;
            ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(cn, "pkg_Afiliados.sp_get_periodo_afil_anterior", ARRPARAM);

        }

        public OracleDataReader Get_Estado_Afil(OracleConnection cn, BE_Afiliados c)
        {
            OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, 4, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("i_cod_dni", OracleDbType.Char, 8, ParameterDirection.Input);
        pr[1].Value = c.Cod_DNI;
        pr[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(cn, "PKG_AFILIADOS.sp_get_estado_afil", pr);
        }

        public OracleDataReader Listar_Tipo_Renuncias(OracleConnection CN, int param1)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[3];
            ARRPARAM[0] = new OracleParameter("i_param1", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[0].Value = param1;
            ARRPARAM[1] = new OracleParameter("i_param2", OracleDbType.Int32, ParameterDirection.Input);
            ARRPARAM[1].Value = 0;
            ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(CN, "pkg_Afiliados.SP_Listar_Renuncias", ARRPARAM);
        }

        public OracleDataReader Listar_Tipo_EstadosAfil(OracleConnection CN)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[1];
            ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(CN, "pkg_Afiliados.sp_Listar_Estados", ARRPARAM);
        }

        public int Cambiar_Estado(BE_Afiliados c)
        {
            OracleParameter[] arrParam = new OracleParameter[11];
            arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            arrParam[0].Value = c.Cod_OP;
            arrParam[1] = new OracleParameter("i_cod_DNI", OracleDbType.Char, ParameterDirection.Input);
            arrParam[1].Value = c.Cod_DNI;
            arrParam[2] = new OracleParameter("i_flg_estado_afil", OracleDbType.Int16, ParameterDirection.Input);
            arrParam[2].Value = c.FLESTADOAFILIACION;
            arrParam[3] = new OracleParameter("i_fec_renuncia", OracleDbType.Date, ParameterDirection.Input);
            if (string.IsNullOrEmpty(c.Fec_Renuncia))
            {
                arrParam[3].Value = DBNull.Value;
            }
            else
            {
                arrParam[3].Value = c.Fec_Renuncia;
            }

            arrParam[4] = new OracleParameter("i_fec_ren_op", OracleDbType.Date, ParameterDirection.Input);
            if (string.IsNullOrEmpty(c.Fec_Renun_OP))
            {
                arrParam[4].Value = DBNull.Value;
            }
            else
            {
                arrParam[4].Value = c.Fec_Renun_OP;
            }

            arrParam[5] = new OracleParameter("i_aspx", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[5].Value = c.Aspx;

            arrParam[6] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[6].Value = c.Observ;

            arrParam[7] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[7].Value = c.CodExpMTD;

            arrParam[8] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[8].Value = c.CodDocMTD;

            arrParam[9] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[9].Value = Yoo.UserId;

            arrParam[10] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        
            ORACLEHELPER.EjecutarQR("Pkg_Afiliados.sp_cambiar_estado", arrParam);

            return Convert.ToInt32(arrParam[10].Value.ToString());
        }

		public int Exclusion(BE_Afiliados c)
		{
			OracleParameter[] arrParam = new OracleParameter[13];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_DNI", OracleDbType.Char, ParameterDirection.Input);
				arrParam[1].Value = c.Cod_DNI;

				arrParam[2] = new OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = c.Cod_DNI;

				arrParam[3] = new OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = c.Cod_DNI;

				arrParam[4] = new OracleParameter("i_nombre", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = c.Cod_DNI;

				arrParam[5] = new OracleParameter("i_flg_estado_afil", OracleDbType.Int16, ParameterDirection.Input);
				arrParam[5].Value = c.FLESTADOAFILIACION;

				arrParam[6] = new OracleParameter("i_fec_renuncia", OracleDbType.Date, ParameterDirection.Input);
				arrParam[6].Value = c.Fec_Renuncia;

				arrParam[7] = new OracleParameter("i_aspx", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[7].Value = c.Aspx;

				arrParam[8] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[8].Value = c.Observ;

				arrParam[9] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[9].Value = c.CodExpMTD;

				arrParam[10] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[10].Value = c.CodDocMTD;

				arrParam[11] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[11].Value = Yoo.UserId;

            arrParam[12] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
				
				ORACLEHELPER.EjecutarQR("Pkg_Afiliados.sp_exclusion", arrParam);

				return Convert.ToInt32(arrParam[12].Value.ToString());

			
		}


		public int Revertir_Exclusion(OracleConnection cn, BE_Afiliados oBE)
		{
			OracleParameter[] arrParam = new OracleParameter[8];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_DNI", OracleDbType.Char, ParameterDirection.Input);
				arrParam[1].Value = oBE.Cod_DNI;

				arrParam[2] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = oBE.Observ;

				arrParam[3] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = oBE.CodExpMTD;

				arrParam[4] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = oBE.CodDocMTD;

				arrParam[5] = new OracleParameter("i_aspx", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[5].Value = oBE.Aspx;

				arrParam[6] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[6].Value = Yoo.UserId;

            arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
			
				ORACLEHELPER.EjecutarQR("Pkg_Afiliados.sp_revertir_exclusion", arrParam);

				return Convert.ToInt32(arrParam[7].Value.ToString());
            
		}


		public OracleDataReader sp_listar_afil_ult4(OracleConnection cn)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = Yoo.UserId;
            ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(cn, "PKG_AFILIADOS.sp_listar_consulta_detalle", ARRPARAM);
			
		}

		public int Limpiar_Consulta_Ult4()
		{
			OracleParameter[] arrParam = new OracleParameter[2];

			
				arrParam[0] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[0].Value = Yoo.UserId;

            arrParam[1] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
			

				ORACLEHELPER.EjecutarQR("PKG_AFILIADOS.SP_LIMP_CONSULTA_AFIL_OPALL", arrParam);

				return (int) arrParam[1].Value;

			
		}

		public int Insert_Ciudadano_Consulta_Ult4( BE_Persona c)
		{
			OracleParameter[] arrParam = new OracleParameter[6];

			
				arrParam[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_Dni;

				arrParam[1] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = Yoo.UserId;

            arrParam[2] = new OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = c.ApePat;

				arrParam[3] = new OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = c.ApeMat;

				arrParam[4] = new OracleParameter("i_nombres", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = c.Nombre;

				arrParam[5] = new OracleParameter("o_return", OracleDbType.Int16,ParameterDirection.Output);
				
				ORACLEHELPER.EjecutarQR("PKG_AFILIADOS.SP_Insert_Consulta_Afil_OP", arrParam);

            return (int)arrParam[5].Value;
            			
		}
	}

