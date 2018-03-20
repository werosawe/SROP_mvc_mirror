using System.Data;
using Oracle.DataAccess.Client;

	public class DA_Menu : DA_BASE
	{
		//Dim MEE As Utilitario.MEE

		public OracleDataReader ListarMenu(OracleConnection CN, BE_Menu c)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];


			ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
			ARRPARAM[0].Value = Yoo.UserId;
            ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

			return ORACLEHELPER.ObtenerDR(CN, "PKG_Listar.sp_Menu_grid", ARRPARAM);

		}

		//Public Function ADD(ByVal c As BE_MenuPadre) As Integer
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(4) {}

		//    ARRPARAM(0) = New OracleParameter("ID_DETALLE_CLASIFICACION", OracleDbType.Int32, ParameterDirection.InputOutput)
		//    ARRPARAM(0).Value = c.ID_DETALLE_CLASIFICACION
		//    ARRPARAM(1) = New OracleParameter("ID_SUB_CLASIFICACION", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(1).Value = c.ID_SUB_CLASIFICACION
		//    ARRPARAM(2) = New OracleParameter("ID_CLASIFICACION", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(2).Value = c.ID_CLASIFICACION
		//    ARRPARAM(3) = New OracleParameter("TX_DETALLE", OracleDbType.NVarchar2, 100, ParameterDirection.Input)
		//    ARRPARAM(3).Value = c.TX_DETALLE
		//    ARRPARAM(4) = New OracleParameter("ID_USU_CRE", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(4).Value = MEE.ID_Usuario
		//    ORACLEHELPER.EjecutarQR("Menu_ADD", ARRPARAM)
		//    Return Dame_Entero(ARRPARAM(0).Value)

		//End Function

		//Public Sub EDIT(ByVal c As BE_MenuPadre)
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(4) {}

		//    ARRPARAM(0) = New OracleParameter("ID_DETALLE_CLASIFICACION", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(0).Value = c.ID_DETALLE_CLASIFICACION
		//    ARRPARAM(1) = New OracleParameter("ID_SUB_CLASIFICACION", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(1).Value = c.ID_SUB_CLASIFICACION
		//    ARRPARAM(2) = New OracleParameter("ID_CLASIFICACION", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(2).Value = c.ID_CLASIFICACION
		//    ARRPARAM(3) = New OracleParameter("TX_DETALLE", OracleDbType.NVarchar2, 100, ParameterDirection.Input)
		//    ARRPARAM(3).Value = c.TX_DETALLE
		//    ARRPARAM(4) = New OracleParameter("ID_USU_CRE", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(4).Value = MEE.ID_Usuario
		//    ORACLEHELPER.EjecutarQR("Menu_EDIT", ARRPARAM)

		//End Sub

		//Public Sub DEL(ByVal c As BE_MenuPadre)
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(1) {}

		//    ARRPARAM(0) = New OracleParameter("ID_DETALLE_CLASIFICACION", OracleDbType.Int32, ParameterDirection.Input)
		//    ARRPARAM(0).Value = c.ID_DETALLE_CLASIFICACION
		//    ARRPARAM(1) = New OracleParameter("ID_USU_MOD", OracleDbType.Varchar2, 30, ParameterDirection.Input)
		//    ARRPARAM(1).Value = MEE.ID_Usuario
		//    ORACLEHELPER.EjecutarQR("Menu_DEL", ARRPARAM)

		//End Sub


		//Public Function ID(ByVal CN As OracleConnection, ByVal c As BE_MenuPadre) As OracleDataReader
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(1) {}

		//    ARRPARAM(0) = New OracleParameter("ID_DETALLE_CLASIFICACION", OracleDbType.Int32, ParameterDirection.InputOutput)
		//    ARRPARAM(0).Value = c.ID_DETALLE_CLASIFICACION
		//    ARRPARAM(1) = New OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output)
		//    Return ORACLEHELPER.ObtenerDR(CN, "PKG_Menu.ID", ARRPARAM)

		//End Function

		//Public Function LST_X_SUB_CLASIFICACION(ByVal CN As OracleConnection, ByVal c As BE_MenuPadre) As OracleDataReader
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(1) {}

		//    ARRPARAM(0) = New OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output)
		//    ARRPARAM(1) = New OracleParameter("ID_SUB_CLASIFICACION", OracleDbType.Int32, ParameterDirection.InputOutput)
		//    ARRPARAM(1).Value = c.ID_SUB_CLASIFICACION
		//    Return ORACLEHELPER.ObtenerDR(CN, "PKG_Menu.LST_X_SUB_CLASIFICACION", ARRPARAM)

		//End Function


		//Public Function LST_X_SUB_CLASIFICACION_ACTIVO(ByVal CN As OracleConnection, ByVal c As BE_MenuPadre) As OracleDataReader
		//    Dim ARRPARAM() As OracleParameter = New OracleParameter(1) {}

		//    ARRPARAM(0) = New OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output)
		//    ARRPARAM(1) = New OracleParameter("ID_SUB_CLASIFICACION", OracleDbType.Int32, ParameterDirection.InputOutput)
		//    ARRPARAM(1).Value = c.ID_SUB_CLASIFICACION
		//    Return ORACLEHELPER.ObtenerDR(CN, "PKG_Menu.LST_X_SUB_CLASIFICACION_ACTIVO", ARRPARAM)

		//End Function
	}

