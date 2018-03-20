using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;


public class DA_Cargo : DA_BASE
{

    public OracleDataReader Listar_Cargos(OracleConnection cn, string Condicion_Busq = "")
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_buscar", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Condicion_Busq;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_repres.sp_cargos_grid", ARRPARAM);

    }

    public OracleDataReader Cargar_Cargos_Internauta(OracleConnection cn, BE_Cargo c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("Cod_DNI", OracleDbType.Char, 8, ParameterDirection.Input);
        pr[1].Value = c.Cod_DNI;
        pr[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_repres.sp_repres_cargos_i", pr);
    }

    public OracleDataReader Cargar_Cargos(OracleConnection cn, BE_Cargo c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("Cod_DNI", OracleDbType.Char, 8, ParameterDirection.Input);
        pr[1].Value = c.Cod_DNI;
        pr[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_repres.sp_representante_dni", pr);

    }

    //Public Function Agregar(ByVal cn As OracleConnection, ByVal Des_Cargo As String) As Int32
    //    Dim arrParam() As OracleParameter = New OracleParameter(1) {}
    //    Try
    //        arrParam(0) = New OracleParameter("i_des_cargo", OracleDbType.Varchar2, ParameterDirection.Input)
    //        arrParam(0).Value = Des_Cargo

    //        arrParam(1) = New OracleParameter("o_return", OracleDbType.Int32)
    //        arrParam(1).Direction = ParameterDirection.Output

    //        ORACLEHELPER.EjecutarQR("pkg_repres.sp_insert_cargos", arrParam)

    //        Return CType(arrParam(1).Value.ToString, Int32)

    //    Catch ex As Exception
    //        Throw ex
    //    End Try
    //End Function

    public List<string> Agregar(BE_Cargo c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];
        arrParam[0] = new OracleParameter("i_des_cargo", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = c.Des_Cargo;
        arrParam[1] = new OracleParameter("o_cod_cargo", OracleDbType.Varchar2, ParameterDirection.Output);
        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_repres.sp_insert_cargos", arrParam);
        List<string> ret = new List<string>();
        ret.Add(arrParam[1].Value.ToString());
        ret.Add(arrParam[2].Value.ToString());
        return ret;

    }

}

