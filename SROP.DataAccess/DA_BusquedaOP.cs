using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

public class DA_BusquedaOP : DA_BASE
{
    public OracleDataReader ListarOPxDenominacion(OracleConnection cn, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;
        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Des_OP.Mayuscula();
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_Listar.sp_op_grid", ARRPARAM);
    }

    public OracleDataReader ListarOPxAbogado(OracleConnection CN, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;

        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.NVarchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.ID_Asistente;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "PKG_Listar.sp_op_x_abogado_grid", ARRPARAM);

    }

    public OracleDataReader ListarOPxTipoOP(OracleConnection CN, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;

        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.NVarchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Cod_Tipo_OP;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "PKG_Listar.sp_op_x_tipo_grid", ARRPARAM);

    }

    public OracleDataReader ListarOPxEstadoOP(OracleConnection CN, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;

        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.NVarchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.ID_EstadoOP;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "PKG_Listar.sp_op_x_estado_grid", ARRPARAM);

    }

    public OracleDataReader ListarOPxFechasEtapas(OracleConnection cn, BE_BusquedaOP.FecEstado c)
    {
        if (c.FecFin == null) c.FecFin = new DateTime();
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_fec_ini", OracleDbType.Date, ParameterDirection.Input);
        ARRPARAM[0].Value = c.FecIni; // .Fecha(UTILITARIO_MUESTRA_FECHA.CLIENTE_FECHA);
        ARRPARAM[1] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
        ARRPARAM[1].Value = c.FecFin;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_Listar.sp_op_x_fecha_etapa_grid", ARRPARAM);
    }

    public OracleDataReader ListarOPxEstado_EnRango_Fechas(OracleConnection CN, BE_BusquedaOP.FecEstado paramFec, BE_BusquedaOP OP)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];
        ARRPARAM[0] = new OracleParameter("i_fec_ini", OracleDbType.Date, ParameterDirection.Input);
        ARRPARAM[0].Value = paramFec.FecIni;
        ARRPARAM[1] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
        ARRPARAM[1].Value = paramFec.FecFin;
        ARRPARAM[2] = new OracleParameter("i_id_estado_op", OracleDbType.Int16, ParameterDirection.Input);
        ARRPARAM[2].Value = OP.ID_EstadoOP;
        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "PKG_Listar.sp_op_x_estado_fecha_grid", ARRPARAM);
    }

    public OracleDataReader ListarOPxUbicDeLegajo(OracleConnection cn, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;
        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.NVarchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Ubic_Legajo;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_Listar.sp_op_x_ubiclegajo_grid", ARRPARAM);
    }


    public OracleDataReader ListarOPxUbigeo(OracleConnection CN, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];
        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;
        ARRPARAM[1] = new OracleParameter("i_cod_tipo_OP", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Cod_Tipo_OP;
        ARRPARAM[2] = new OracleParameter("i_descripcion", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[2].Value = c.UBIGEO;
        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "PKG_Listar.sp_op_x_ubigeo_grid", ARRPARAM);
    }

    public OracleDataReader ListarOPxRegion(OracleConnection cn, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;
        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.UBIGEO.Substring(0, 2);
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_Listar.sp_op_x_region_grid", ARRPARAM);
    }

    public OracleDataReader ListarOPxProvincia(OracleConnection CN, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;
        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.UBIGEO.Substring(0, 4);
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "PKG_Listar.sp_op_x_provincia_grid", ARRPARAM);
    }

    public OracleDataReader ListarOPxDistrito(OracleConnection cn, BE_BusquedaOP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Yoo.UserId;
        ARRPARAM[1] = new OracleParameter("i_descripcion", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.UBIGEO.Substring(0, 6);
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_Listar.sp_op_x_distrito_grid", ARRPARAM);
    }

}

