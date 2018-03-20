using System;
using System.Data;
using Oracle.DataAccess.Client;

	public class DA_opPDF : DA_BASE
	{

		public OracleDataReader Obtener_PDF_Page(OracleConnection CN, BE_opPDF c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[3];
			
				ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = c.Cod_OP;

				ARRPARAM[1] = new OracleParameter("I_N_PAGE", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[1].Value = c.N_Page_Curr;

				ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_exp_pdf.sp_pdf_page_sel", ARRPARAM);
			
		}

		public OracleDataReader Datos_PDF(OracleConnection cn, Int32 Cod_OP)
		{
			OracleParameter[] arrParam = new OracleParameter[2];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = Cod_OP;

				arrParam[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(cn, "pkg_exp_pdf.sp_pdf_data", arrParam);
			
		}

		public void Save_BLOB(OracleConnection cn, BE_opPDF c)
		{

			if ((c.PDF_Page != null)) {
				OracleCommand cmd = new OracleCommand();
				cn.Open();

				cmd = cn.CreateCommand();
				cmd.CommandText = "pkg_exp_pdf.sp_pdf_save_blob";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new OracleParameter("i_cod_op", OracleDbType.Int32)).Value = c.Cod_OP;
				cmd.Parameters.Add(new OracleParameter("i_n_page", OracleDbType.Int32)).Value = c.N_Page_Curr;
				cmd.Parameters.Add(new OracleParameter("i_pdf_page", OracleDbType.Blob)).Value = c.PDF_Page;
				cmd.Parameters.Add(new OracleParameter("i_userid", OracleDbType.Varchar2)).Value = Yoo.UserId;
                cmd.ExecuteNonQuery();
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

		public string Borrar_PagePDF(BE_opPDF c)
		{
			OracleParameter[] arrParam = new OracleParameter[4];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_n_page", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.N_Page_Curr;

				arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = Yoo.UserId;

            arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[3].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_exp_pdf.SP_PDF_PAGE_DELETE", arrParam);

				return Convert.ToString(arrParam[3].Value.ToString());
            
		}

		public string Borrar_TodoPDF(BE_opPDF c)
		{
			OracleParameter[] arrParam = new OracleParameter[3];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = Yoo.UserId;

            arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[2].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_exp_pdf.SP_PDF_TODO_DELETE", arrParam);

				return Convert.ToString(arrParam[2].Value.ToString());
            
		}


		public OracleDataReader Listar_Indice(OracleConnection CN, Int32 Cod_OP)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = Cod_OP;
				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_exp_pdf.sp_indice_grid", ARRPARAM);
			
		}


		public string Add_Pagina_Indice(BE_opPDF c)
		{
			OracleParameter[] arrParam = new OracleParameter[5];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_tema_indice", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = c.Tema_Indice;

				arrParam[2] = new OracleParameter("i_pagina_indice", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[2].Value = c.Pagina_Indice;

				arrParam[3] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[3].Value = Yoo.UserId;

            arrParam[4] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[4].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_exp_pdf.SP_Indice_add", arrParam);

				return Convert.ToString(arrParam[4].Value.ToString());
            
		}

		public string Ins_Pagina_Indice(BE_opPDF c)
		{
			OracleParameter[] arrParam = new OracleParameter[4];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_id_indice", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Id_Indice;

				arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = Yoo.UserId;

            arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[3].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_exp_pdf.SP_Indice_ins", arrParam);

				return Convert.ToString(arrParam[3].Value.ToString());

			
		}

		public string Update_Pagina_Indice(BE_opPDF c)
		{
			OracleParameter[] arrParam = new OracleParameter[6];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_id_indice", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Id_Indice;

				arrParam[2] = new OracleParameter("i_tema_indice", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = c.Tema_Indice;

				arrParam[3] = new OracleParameter("i_pagina_indice", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[3].Value = c.Pagina_Indice;

				arrParam[4] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = Yoo.UserId;

            arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[5].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_exp_pdf.SP_Indice_update", arrParam);

				return Convert.ToString(arrParam[5].Value.ToString());
            
		}

		public string Delete_Pagina_Indice(BE_opPDF c)
		{
			OracleParameter[] arrParam = new OracleParameter[4];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_id_indice", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Id_Indice;

				arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = Yoo.UserId;

            arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[3].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_exp_pdf.SP_Indice_delete", arrParam);

				return Convert.ToString(arrParam[3].Value.ToString());
            
		}

		public string Crear_Indice_Basico(BE_opPDF c)
		{
			OracleParameter[] arrParam = new OracleParameter[3];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[1].Value = Yoo.UserId;

            arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32);
				arrParam[2].Direction = ParameterDirection.Output;

				ORACLEHELPER.EjecutarQR("pkg_exp_pdf.SP_crear_indice_basico", arrParam);

				return Convert.ToString(arrParam[2].Value.ToString());
            
		}

	}

