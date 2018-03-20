using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


	public class DA_ComiteVF : DA_BASE
	{

		#region "Procedimientos de consulta"

		//Public Function Listar_Afiliados(ByVal CN As OracleConnection, oBE_ComiteAfil As BE_ComiteAfil) As OracleDataReader
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(5) {}
		//    Try
		//        ARRPARAM(0) = New OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(0).Value = Dame_Entero(oBE_ComiteAfil.Cod_OP)

		//        ARRPARAM(1) = New OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(1).Value = Dame_Entero(oBE_ComiteAfil.Nro_Entrega)

		//        ARRPARAM(2) = New OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(2).Value = Dame_Entero(oBE_ComiteAfil.UbiRegion)

		//        ARRPARAM(3) = New OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(3).Value = Dame_Entero(oBE_ComiteAfil.UbiProv)

		//        ARRPARAM(4) = New OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(4).Value = Dame_Entero(oBE_ComiteAfil.UbiDist)

		//        ARRPARAM(5) = New OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output)

		//        Return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_comites_afil_grid", ARRPARAM)
		//    Catch EX As Exception
		//        Throw EX
		//    End Try
		//End Function

		//Public Function Listar_Afiliados_Busq(ByVal CN As OracleConnection, oBE_ComiteAfil As BE_ComiteAfil) As OracleDataReader
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(6) {}
		//    Try
		//        ARRPARAM(0) = New OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(0).Value = Dame_Entero(oBE_ComiteAfil.Cod_OP)

		//        ARRPARAM(1) = New OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(1).Value = Dame_Entero(oBE_ComiteAfil.Nro_Entrega)

		//        ARRPARAM(2) = New OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(2).Value = Dame_Entero(oBE_ComiteAfil.UbiRegion)

		//        ARRPARAM(3) = New OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(3).Value = Dame_Entero(oBE_ComiteAfil.UbiProv)

		//        ARRPARAM(4) = New OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input)
		//        ARRPARAM(4).Value = Dame_Entero(oBE_ComiteAfil.UbiDist)

		//        ARRPARAM(5) = New OracleParameter("i_search", OracleDbType.Varchar2, ParameterDirection.Input)
		//        ARRPARAM(5).Value = Dame_Texto(oBE_ComiteAfil.Cond_Busqueda)

		//        ARRPARAM(6) = New OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output)

		//        Return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_comites_afil_grid_busq", ARRPARAM)
		//    Catch EX As Exception
		//        Throw EX
		//    End Try
		//End Function

		//Public Function Listar_MotivoBaja(ByVal CN As OracleConnection) As OracleDataReader
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(0) {}
		//    Try
		//        ARRPARAM(0) = New OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output)

		//        Return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_motivobaja_grid", ARRPARAM)
		//    Catch EX As Exception
		//        Throw EX
		//    End Try
		//End Function

		#endregion

		#region "Procedimientos de transaccion"

		//Public Function Agregar(ByVal cn As OracleConnection, oBE_ComiteAfil As BE_ComiteAfil) As Int32
		//    Dim arrParam() As OracleParameter = New OracleParameter(7) {}
		//    Try
		//        arrParam(0) = New OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(0).Value = oBE_ComiteAfil.Cod_OP

		//        arrParam(1) = New OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(1).Value = oBE_ComiteAfil.Nro_Entrega

		//        arrParam(2) = New OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(2).Value = oBE_ComiteAfil.Cod_Dni

		//        arrParam(3) = New OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(3).Value = oBE_ComiteAfil.UbiRegion

		//        arrParam(4) = New OracleParameter("i_prov", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(4).Value = oBE_ComiteAfil.UbiProv

		//        arrParam(5) = New OracleParameter("i_dist", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(5).Value = oBE_ComiteAfil.UbiDist

		//        arrParam(6) = New OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(6).Value = oBE_ComiteAfil.UserID

		//        arrParam(7) = New OracleParameter("o_return", OracleDbType.Int32)
		//        arrParam(7).Direction = ParameterDirection.Output

		//        ORACLEHELPER.EjecutarQR("pkg_comites.sp_insert_comites_afil", arrParam)

		//        Return CType(arrParam(7).Value.ToString, Int32)

		//    Catch ex As Exception
		//        Throw ex
		//    End Try
		//End Function

		public int Modificar(BE_ComiteVF c)
		{
			OracleParameter[] arrParam = new OracleParameter[6];

			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_nro_presen", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Nro_Presen;

				arrParam[2] = new OracleParameter("i_fec_envio_vf", OracleDbType.Date, ParameterDirection.Input);
				arrParam[2].Value = c.Fec_Envio_Vf;

				arrParam[3] = new OracleParameter("i_fec_recep_vf", OracleDbType.Date, ParameterDirection.Input);
				arrParam[3].Value = c.Fec_Recep_Vf;

				arrParam[4] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[4].Value = Yoo.UserId;

            arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32,ParameterDirection.Output);
				
				ORACLEHELPER.EjecutarQR("pkg_comites.sp_update_vf_comites_fec_envio", arrParam);

				return Convert.ToInt32(arrParam[5].Value.ToString());

			
		}

		public int Modificar_Reniec(BE_ComiteVF_Reniec c)
		{
			OracleParameter[] arrParam = new OracleParameter[13];
			
				arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[0].Value = c.Cod_OP;

				arrParam[1] = new OracleParameter("i_nro_presen", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[1].Value = c.Nro_Presen;

				arrParam[2] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[2].Value = c.Cod_Dni;

				arrParam[3] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[3].Value = c.UbiReg;

				arrParam[4] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[4].Value = c.UbiProv;

				arrParam[5] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
				arrParam[5].Value = c.UbiDist;

				arrParam[6] = new OracleParameter("i_cod_resultado_vf", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[6].Value = c.Cod_Resultado_Vf;

				arrParam[7] = new OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[7].Value = c.ApePat;

				arrParam[8] = new OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[8].Value = c.ApeMat;

				arrParam[9] = new OracleParameter("i_nombres", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[9].Value = c.Nombres;

				arrParam[10] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[10].Value = Yoo.UserId;

            arrParam[11] = new OracleParameter("i_tx_obs_reniec", OracleDbType.Varchar2, ParameterDirection.Input);
				arrParam[11].Value = c.tx_Obs_RENIEC;

				arrParam[12] = new OracleParameter("o_return", OracleDbType.Int32,ParameterDirection.Output);
				

				ORACLEHELPER.EjecutarQR("pkg_comites.sp_update_vf_comites_reniec", arrParam);

				return Convert.ToInt32(arrParam[12].Value.ToString());
            
		}

		//Public Function Modificar_Reniec(ByVal cn As OracleConnection, oBE_ComiteVF_Reniec As BE_ComiteVF_Reniec) As Int32
		//    Dim arrParam() As OracleParameter = New OracleParameter(12) {}
		//    Try

		//        arrParam(0) = New OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(0).Value = oBE_ComiteVF_Reniec.Cod_OP

		//        arrParam(1) = New OracleParameter("i_nro_presen", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(1).Value = oBE_ComiteVF_Reniec.Nro_Presen

		//        arrParam(2) = New OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(2).Value = oBE_ComiteVF_Reniec.Cod_Dni

		//        arrParam(3) = New OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(3).Value = oBE_ComiteVF_Reniec.UbiReg

		//        arrParam(4) = New OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(4).Value = oBE_ComiteVF_Reniec.UbiProv

		//        arrParam(5) = New OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(5).Value = oBE_ComiteVF_Reniec.UbiDist

		//        arrParam(6) = New OracleParameter("i_cod_resultado_vf", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(6).Value = oBE_ComiteVF_Reniec.Cod_Resultado_Vf

		//        arrParam(7) = New OracleParameter("i_apepat", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(7).Value = oBE_ComiteVF_Reniec.ApePat

		//        arrParam(8) = New OracleParameter("i_apemat", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(8).Value = oBE_ComiteVF_Reniec.ApeMat

		//        arrParam(9) = New OracleParameter("i_nombres", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(9).Value = oBE_ComiteVF_Reniec.Nombres

		//        arrParam(10) = New OracleParameter("i_tx_obs_reniec", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(10).Value = oBE_ComiteVF_Reniec.tx_Obs_RENIEC

		//        arrParam(11) = New OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(11).Value = oBE_ComiteVF_Reniec.UserID

		//        arrParam(12) = New OracleParameter("o_return", OracleDbType.Int32)
		//        arrParam(12).Direction = ParameterDirection.Output

		//        ORACLEHELPER.EjecutarQR("pkg_comites.sp_update_tx_obs_reniec", arrParam)

		//        Return CType(arrParam(12).Value.ToString, Int32)

		//    Catch ex As Exception
		//        Throw ex
		//    End Try
		//End Function

		//Public Function Eliminar(ByVal cn As OracleConnection, oBE_ComiteAfil As BE_ComiteAfil) As Int32
		//    Dim arrParam() As OracleParameter = New OracleParameter(7) {}
		//    Try
		//        arrParam(0) = New OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(0).Value = oBE_ComiteAfil.Cod_OP

		//        arrParam(1) = New OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(1).Value = oBE_ComiteAfil.Nro_Entrega

		//        arrParam(2) = New OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(2).Value = oBE_ComiteAfil.Cod_Dni

		//        arrParam(3) = New OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(3).Value = oBE_ComiteAfil.Region

		//        arrParam(4) = New OracleParameter("i_prov", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(4).Value = CType(oBE_ComiteAfil.Provincia, Date)

		//        arrParam(5) = New OracleParameter("i_dist", OracleDbType.Int32, ParameterDirection.Input)
		//        arrParam(5).Value = oBE_ComiteAfil.Distrito

		//        arrParam(6) = New OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input)
		//        arrParam(6).Value = oBE_ComiteAfil.UserID

		//        arrParam(7) = New OracleParameter("o_return", OracleDbType.Int32)
		//        arrParam(7).Direction = ParameterDirection.Output

		//        ORACLEHELPER.EjecutarQR("pkg_comites.sp_delete_comite_afil", arrParam)

		//        Return CType(arrParam(7).Value.ToString, Int32)

		//    Catch ex As Exception
		//        Throw ex
		//    End Try
		//End Function
		#endregion

	}

