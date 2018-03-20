using System;
using System.Data;
using Oracle.DataAccess.Client;



	public class DA_Constancia : DA_BASE
	{

		public OracleDataReader Emisor_Constancia(OracleConnection cn, BE_Constancia c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = Yoo.UserId;

            ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(cn, "PKG_AFILIADOS.sp_Emisor_Constancia", ARRPARAM);
			
		}

		public OracleDataReader Get_Constancia_Afil(OracleConnection CN, BE_Constancia c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];
			
				ARRPARAM[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_DNI;

				ARRPARAM[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Num_Const;

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "PKG_AFILIADOS.SP_Get_Constancia", ARRPARAM);
			
		}

		public OracleDataReader Listar_Constancias_Afil(OracleConnection CN, BE_Constancia c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_DNI;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_Afiliados.sp_listar_constancias", ARRPARAM);
			
		}

		public string Eliminar(BE_Constancia c)
		{
			OracleParameter[] arrParam = new OracleParameter[4];

			
				arrParam[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_DNI;

				arrParam[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Num_Const;

				arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = Yoo.UserId;

            arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32,ParameterDirection.Output);
			
				ORACLEHELPER.EjecutarQR("PKG_AFILIADOS.SP_DELETE_CONST", arrParam);

				return Convert.ToString(arrParam[3].Value.ToString());
            
		}

        public BE_Constancia.Constancia_Afil Update(BE_Constancia c)
        {
            BE_Constancia.Constancia_Afil oRet = new BE_Constancia.Constancia_Afil();
            OracleParameter[] arrParam = new OracleParameter[11];


            arrParam[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
            arrParam[0].Value = c.Cod_DNI;

            arrParam[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
            arrParam[1].Value = c.Num_Const;

            arrParam[2] = new OracleParameter("i_fec_const", OracleDbType.Date, ParameterDirection.Input);
            arrParam[2].Value = c.Fecha;

        arrParam[3] = new OracleParameter("i_solicitante", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[3].Value = c.Solicitante;

            arrParam[4] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[4].Value = c.FileName;

            arrParam[5] = new OracleParameter("i_ruta", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[5].Value = c.RutaDestino;

            arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[6].Value = Yoo.UserId;

            arrParam[7] = new OracleParameter("i_cod_ente", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[7].Value = c.Cod_Ente_Emisor;

            arrParam[8] = new OracleParameter("o_num_const", OracleDbType.Int32, ParameterDirection.Output);

            arrParam[9] = new OracleParameter("o_pdf", OracleDbType.Varchar2, ParameterDirection.Output);
            arrParam[9].Size = 50;

            arrParam[10] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

            ORACLEHELPER.EjecutarQR("pkg_Afiliados.SP_UPdate_const", arrParam);

            oRet.oNum_Const = (int)arrParam[8].Value;
            oRet.oPDF = (string)arrParam[9].Value;
            oRet.retorno = (int)arrParam[10].Value;

            return oRet;

        }

    public BE_Constancia.Constancia_Afil Insert(BE_Constancia c)
    {
        BE_Constancia.Constancia_Afil oRet = new BE_Constancia.Constancia_Afil();
        OracleParameter[] arrParam = new OracleParameter[11];


        arrParam[0] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_DNI;

        arrParam[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Num_Const;

        arrParam[2] = new OracleParameter("i_fec_const", OracleDbType.Date, ParameterDirection.Input);
        //arrParam(2).Value = CType(oBE.Fecha, Date)
        arrParam[2].Value = c.Fecha;

        arrParam[3] = new OracleParameter("i_solicitante", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Solicitante;

        arrParam[4] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.FileName;

        arrParam[5] = new OracleParameter("i_ruta", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = c.RutaDestino;

        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("i_cod_ente", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = c.Cod_Ente_Emisor;

        arrParam[8] = new OracleParameter("o_num_const", OracleDbType.Int32, ParameterDirection.Output);

        arrParam[9] = new OracleParameter("o_pdf", OracleDbType.Varchar2, ParameterDirection.Output);
        arrParam[9].Size = 200;

        arrParam[10] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_Afiliados.SP_Insert_const", arrParam);

        oRet.oNum_Const = (int)arrParam[8].Value;
        oRet.oPDF = (string)arrParam[9].Value;
        oRet.retorno = (int)arrParam[10].Value;

        return oRet;

    }

		public OracleDataReader Listar_Constancias_OP(OracleConnection CN, BE_Constancia c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_constancias_op", ARRPARAM);
			
		}

		public OracleDataReader Get_Constancia_OP(OracleConnection CN, BE_Constancia c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Num_Const;

				ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_op.SP_Get_Constancia", ARRPARAM);
            
		}

        public string Eliminar_Const_OP(BE_Constancia c)
        {
            OracleParameter[] arrParam = new OracleParameter[4];

            arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
            arrParam[0].Value = c.Cod_OP;

            arrParam[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
            arrParam[1].Value = c.Num_Const;

            arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
            arrParam[2].Value = Yoo.UserId;

            arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

            ORACLEHELPER.EjecutarQR("pkg_OP.SP_DELETE_CONST", arrParam);

            return Convert.ToString(arrParam[3].Value.ToString());

        }

		public BE_Constancia.Constancia_OP Update_Constancia_OP(BE_Constancia oBE)
		{
			BE_Constancia.Constancia_OP oRet = new BE_Constancia.Constancia_OP();
			OracleParameter[] arrParam = new OracleParameter[12];
            
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = oBE.Num_Const;

				arrParam[2] = new OracleParameter("i_cod_ente", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = oBE.Cod_Ente_Constancia;

				arrParam[3] = new OracleParameter("i_fec_const", OracleDbType.Date, ParameterDirection.Input);
				arrParam[3].Value = Convert.ToDateTime(oBE.fec_const);

				arrParam[4] = new OracleParameter("i_dni_solic", OracleDbType.Char, ParameterDirection.Input);
				arrParam[4].Value = oBE.Cod_DNI;

				arrParam[5] = new OracleParameter("i_solicitante", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[5].Value = oBE.Solicitante;

				arrParam[6] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[6].Value = oBE.FileName;

				arrParam[7] = new OracleParameter("i_ruta", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[7].Value = oBE.RutaDestino;

				arrParam[8] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[8].Value = Yoo.UserId;

            arrParam[9] = new OracleParameter("o_num_const", OracleDbType.Int32,ParameterDirection.Output);
			
				arrParam[10] = new OracleParameter("o_pdf", OracleDbType.Varchar2,ParameterDirection.Output);
				arrParam[10].Size = 50;
			
				arrParam[11] = new OracleParameter("o_return", OracleDbType.Int32,ParameterDirection.Output);
			
				ORACLEHELPER.EjecutarQR("pkg_op.SP_UPdate_const", arrParam);

				oRet.oNum_Const = (int)arrParam[9].Value;
				oRet.oPDF = (string)arrParam[10].Value;
				oRet.retorno =(int)arrParam[11].Value;

				return oRet;
            
		}

		public BE_Constancia.Constancia_OP Insert_Constancia_OP(BE_Constancia oBE)
		{
			BE_Constancia.Constancia_OP oRet = new BE_Constancia.Constancia_OP();
			OracleParameter[] arrParam = new OracleParameter[12];


			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_num_const", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = oBE.Num_Const;

				arrParam[2] = new OracleParameter("i_cod_ente", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = oBE.Cod_Ente_Constancia;

				arrParam[3] = new OracleParameter("i_fec_const", OracleDbType.Date, ParameterDirection.Input);
				arrParam[3].Value = Convert.ToDateTime(oBE.fec_const);

				arrParam[4] = new OracleParameter("i_dni_solic", OracleDbType.Char, ParameterDirection.Input);
				arrParam[4].Value = oBE.Cod_DNI;

				arrParam[5] = new OracleParameter("i_solicitante", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[5].Value = oBE.Solicitante;

				arrParam[6] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[6].Value = oBE.FileName;

				arrParam[7] = new OracleParameter("i_ruta", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[7].Value = oBE.RutaDestino;

				arrParam[8] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[8].Value = Yoo.UserId;

            arrParam[9] = new OracleParameter("o_num_const", OracleDbType.Int32,ParameterDirection.Output);
				
				arrParam[10] = new OracleParameter("o_pdf", OracleDbType.Varchar2,ParameterDirection.Output);
				arrParam[10].Size = 50;
			
				arrParam[11] = new OracleParameter("o_return", OracleDbType.Int32,ParameterDirection.Output);
				
				ORACLEHELPER.EjecutarQR("pkg_op.SP_INSERT_const", arrParam);

				oRet.oNum_Const = (int)arrParam[9].Value;
				oRet.oPDF = (string)arrParam[10].Value;
				oRet.retorno = (int)arrParam[11].Value;

				return oRet;
            
		}

		public OracleDataReader Listar_Constancias_Afil_x_Ente(OracleConnection CN, string sCod_Ente)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_ente", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = sCod_Ente;

				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "PKG_AFILIADOS.SP_List_Const_Afil_x_Ente", ARRPARAM);
			
				
		}

	}


