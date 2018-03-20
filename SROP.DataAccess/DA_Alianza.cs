using System.Data;
using Oracle.DataAccess.Client;

	public class DA_Alianza : DA_BASE
	{

		public OracleDataReader Listar_OPs_Alianza(OracleConnection CN, BE_Alianza c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[7];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("i_cod_tipo_elecc", OracleDbType.Varchar2, 2, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Cod_Tipo_Elecc;

				ARRPARAM[2] = new OracleParameter("i_proceso_elecc", OracleDbType.Varchar2, 2, ParameterDirection.Input);
				ARRPARAM[2].Value = c.proceso_elecc;

				ARRPARAM[3] = new OracleParameter("i_ubireg", OracleDbType.Int16, 2, ParameterDirection.Input);
				ARRPARAM[3].Value = c.ubireg;

				ARRPARAM[4] = new OracleParameter("i_ubiprov", OracleDbType.Int16, 2, ParameterDirection.Input);
				ARRPARAM[4].Value = c.ubiprov;

				ARRPARAM[5] = new OracleParameter("i_ubidist", OracleDbType.Int16, 2, ParameterDirection.Input);
				ARRPARAM[5].Value = c.ubidist;

				ARRPARAM[6] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.SP_OP_Asoc", ARRPARAM);
			
		}

		public OracleDataReader Listar_Proceso_Electoral(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_proceso_electoral", ARRPARAM);
			
		}

		public OracleDataReader Listar_Tipo_Elecc(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.SP_TipoElecc_01", ARRPARAM);
			
		}

		public OracleDataReader Listar_Tipo_Elecc_02(OracleConnection CN, string cod_tipo_elecc)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_tipo_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				ARRPARAM[0].Value = cod_tipo_elecc;

				ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.SP_TipoElecc_02", ARRPARAM);
			
		}

		public OracleDataReader Lst_AlianzaElectoral(OracleConnection CN, int cod_op)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = cod_op;

				ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_alianza_electoral", ARRPARAM);
			
		}

		public OracleDataReader Lst_AlianzasGrid(OracleConnection CN, int cod_op)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = cod_op;

				ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_alianzas_grid", ARRPARAM);
			
				
		}

		public OracleDataReader Lst_AlianzasListar(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];

			
				ARRPARAM[0] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_alianzas_listar", ARRPARAM);
			
		}

		public OracleDataReader Lst_AlianzasMiembros(OracleConnection CN, int cod_op)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = cod_op;

				ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_alianzas_miembros", ARRPARAM);
			
		}

		public OracleDataReader Lst_AlianzasTipoElecc(OracleConnection CN, int cod_op)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = cod_op;

				ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_alianzas_tipo_elecc", ARRPARAM);
			
		}

		public OracleDataReader Lst_AlianzasUbigeo(OracleConnection CN, int cod_op, string cod_tipo_elecc)
		{

			OracleParameter[] ARRPARAM = new OracleParameter[3];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = cod_op;

				ARRPARAM[1] = new OracleParameter("i_cod_tipo_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				ARRPARAM[1].Value = cod_tipo_elecc;

				ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_alianzas_ubigeo", ARRPARAM);
			
		}

		public OracleDataReader Lst_AlianzasOP(OracleConnection CN, BE_Alianza c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[6];

			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("i_cod_tipo_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				ARRPARAM[1].Value = c.Cod_Tipo_Elecc;

				ARRPARAM[2] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[2].Value = c.ubireg;

				ARRPARAM[3] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[3].Value = c.ubiprov;

				ARRPARAM[4] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[4].Value = c.ubidist;

				ARRPARAM[5] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

				return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_alianzas_op", ARRPARAM);
			
				
		}

		public int Delete_OP_Asoc(BE_Alianza oBE)
		{
			OracleParameter[] arrParam = new OracleParameter[8];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = oBE.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_op_asoc", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = oBE.cod_op_asoc;

				arrParam[2] = new OracleParameter("i_cod_tipo_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				arrParam[2].Value = oBE.Cod_Tipo_Elecc;

				arrParam[3] = new OracleParameter("i_proceso_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				arrParam[3].Value = oBE.IDProcesoElec;

				arrParam[4] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = oBE.ubireg;

				arrParam[5] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[5].Value = oBE.ubiprov;

				arrParam[6] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[6].Value = oBE.ubidist;

				arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

				ORACLEHELPER.EjecutarQR("pkg_op.SP_Delete_OP_Asoc", arrParam);

				return (int) arrParam[7].Value;

			
		}

		public int Adiciona_OP_Asoc( BE_Alianza c)
		{
			OracleParameter[] arrParam = new OracleParameter[10];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_op_asoc", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.cod_op_asoc;

				arrParam[2] = new OracleParameter("i_cod_tipo_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				arrParam[2].Value = c.Cod_Tipo_Elecc;

				arrParam[3] = new OracleParameter("i_proceso_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				arrParam[3].Value = c.IDProcesoElec;

				arrParam[4] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = c.ubireg;

				arrParam[5] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[5].Value = c.ubiprov;

				arrParam[6] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[6].Value = c.ubidist;

				arrParam[7] = new OracleParameter("i_userid", OracleDbType.Varchar2, 50, ParameterDirection.Input);
				arrParam[7].Value = Yoo.UserId;

            arrParam[8] = new OracleParameter("o_des_op", OracleDbType.Varchar2, ParameterDirection.Output);
				arrParam[8].Size = 300;

				arrParam[9] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

				ORACLEHELPER.EjecutarQR("pkg_OP.SP_Insert_OP_Asoc", arrParam);

				return (int)arrParam[9].Value;

            
		}

		public int Update_OP_Asoc(BE_Alianza c)
		{
			OracleParameter[] arrParam = new OracleParameter[11];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_cod_op_asoc", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.cod_op_asoc;

				arrParam[2] = new OracleParameter("i_cod_tipo_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				arrParam[2].Value = c.Cod_Tipo_Elecc;

				arrParam[3] = new OracleParameter("i_proceso_elecc", OracleDbType.Char, 2, ParameterDirection.Input);
				arrParam[3].Value = c.IDProcesoElec;

				arrParam[4] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = c.ubireg;

				arrParam[5] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[5].Value = c.ubiprov;

				arrParam[6] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[6].Value = c.ubidist;

				arrParam[7] = new OracleParameter("i_flg_asociado", OracleDbType.Int16, ParameterDirection.Input);
				arrParam[7].Value = c.FLASOCIADO;

				arrParam[8] = new OracleParameter("i_observ", OracleDbType.Varchar2, 200, ParameterDirection.Input);
				arrParam[8].Value = c.Observ;

				arrParam[9] = new OracleParameter("i_user", OracleDbType.Varchar2, 50, ParameterDirection.Input);
				arrParam[9].Value = Yoo.UserId;

            arrParam[10] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

				ORACLEHELPER.EjecutarQR("pkg_OP.SP_Update_OP_Asoc", arrParam);

				return (int)arrParam[10].Value;
            
		}


	}

