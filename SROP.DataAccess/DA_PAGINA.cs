using Oracle.DataAccess.Client; 
using System.Data;
/// Project	 : DA
/// Class	 : DA_PAGINA
///
/// -----------------------------------------------------------------------------
/// <summary>
///
/// </summary>
/// <remarks>
/// </remarks>
/// <history>
/// 	[Jonatan Abregu Chalco]	07/06/2017	Created
/// </history>
public class DA_PAGINA : DA_BASE
{
    /// <summary>
    ///   Procedimiento de acceso a datos para agregar un registro
    /// </summary>
    /// <param name="c"></param>
    /// <returns>int</returns>
    public int ADD(BE_PAGINA c)
    {
        OracleParameter[] arrParam = new OracleParameter[10];
        arrParam[0] = new OracleParameter("IDAREA", OracleDbType.Int32);
        arrParam[0].Value = c.IDAREA;
        arrParam[1] = new OracleParameter("NUORDEN", OracleDbType.Int32);
        arrParam[1].Value = c.NUORDEN;
        arrParam[2] = new OracleParameter("TXTITULOFLOTANTE", OracleDbType.Varchar2, 150);
        arrParam[2].Value = c.TXTITULOFLOTANTE;
        arrParam[3] = new OracleParameter("IDPAGINAPADRE", OracleDbType.Int32);
        arrParam[3].Value = c.IDPAGINAPADRE;
        arrParam[4] = new OracleParameter("TXCONTROLADOR", OracleDbType.Varchar2, 100);
        arrParam[4].Value = c.TXCONTROLADOR;
        arrParam[5] = new OracleParameter("TXACCION", OracleDbType.Varchar2, 100);
        arrParam[5].Value = c.TXACCION;
        arrParam[6] = new OracleParameter("IDPAGINA", OracleDbType.Int32, ParameterDirection.InputOutput);
        arrParam[6].Value = c.IDPAGINA;
        arrParam[7] = new OracleParameter("TXROL", OracleDbType.Varchar2, 100);
        arrParam[7].Value = c.TXROL;
        arrParam[8] = new OracleParameter("TXTITULO", OracleDbType.Varchar2, 100);
        arrParam[8].Value = c.TXTITULO;

        arrParam[9] = new OracleParameter("IDUSUCRE", OracleDbType.Int32, 4);
        arrParam[9].Value = Yoo.UserId;
        ORACLEHELPER.EjecutarQR("PAGINA_ADD", arrParam);
        return (int)arrParam[6].Value;
    }

    /// <summary>
    ///   Procedimiento de Acceso a Datos para Editar el Registro
    /// </summary>
    /// <param name="cn"></param>
    /// <param name="c"></param>
    public void EDIT(OracleConnection cn, BE_PAGINA c)
    {
        OracleParameter[] arrParam = new OracleParameter[10];
        arrParam[0] = new OracleParameter("IDAREA", OracleDbType.Int32);
        arrParam[0].Value = c.IDAREA;
        arrParam[1] = new OracleParameter("NUORDEN", OracleDbType.Int32);
        arrParam[1].Value = c.NUORDEN;
        arrParam[2] = new OracleParameter("TXTITULOFLOTANTE", OracleDbType.Varchar2, 150);
        arrParam[2].Value = c.TXTITULOFLOTANTE;
        arrParam[3] = new OracleParameter("IDPAGINAPADRE", OracleDbType.Int32);
        arrParam[3].Value = c.IDPAGINAPADRE;
        arrParam[4] = new OracleParameter("TXCONTROLADOR", OracleDbType.Varchar2, 100);
        arrParam[4].Value = c.TXCONTROLADOR;
        arrParam[5] = new OracleParameter("TXACCION", OracleDbType.Varchar2, 100);
        arrParam[5].Value = c.TXACCION;
        arrParam[6] = new OracleParameter("IDPAGINA", OracleDbType.Int32);
        arrParam[6].Value = c.IDPAGINA;
        arrParam[7] = new OracleParameter("TXROL", OracleDbType.Varchar2, 100);
        arrParam[7].Value = c.TXROL;
        arrParam[8] = new OracleParameter("TXTITULO", OracleDbType.Varchar2, 100);
        arrParam[8].Value = c.TXTITULO;
        arrParam[9] = new OracleParameter("IDUSUMOD", OracleDbType.Int32, 4);
        arrParam[9].Value = Yoo.UserId;
        ORACLEHELPER.EjecutarQR("PAGINA_EDIT", arrParam);
    }

    /// <summary>
    /// Procedimiento de Acceso a Datos para cambiar de estado al Registro
    /// </summary>
    /// <param name="c"></param>
    public void EDIT_EST(BE_PAGINA c)
    {
        OracleParameter[] arrParam = new OracleParameter[2];
        arrParam[0] = new OracleParameter("IDPAGINA", OracleDbType.Int32);
        arrParam[0].Value = c.IDPAGINA;
        arrParam[1] = new OracleParameter("IDESTREG", OracleDbType.Int32);
        arrParam[1].Value = c.IDESTREG;
        arrParam[2] = new OracleParameter("IDUSUMOD", OracleDbType.Int32, 4);
        arrParam[2].Value = Yoo.UserId;
        ORACLEHELPER.EjecutarQR("PAGINA_EDIT_EST", arrParam);
    }

    /// <summary>
    /// Procedimiento de Acceso a Datos para eliminar un Registro
    /// </summary>
    /// <param name="c"></param>
    public void DEL(BE_PAGINA c)
    {
        OracleParameter[] arrParam = new OracleParameter[2];
        arrParam[0] = new OracleParameter("IDPAGINA", OracleDbType.Int32);
        arrParam[0].Value = c.IDPAGINA;
        arrParam[1] = new OracleParameter("IDUSUELI", OracleDbType.Int32, 4);
        arrParam[1].Value = Yoo.UserId;
        ORACLEHELPER.EjecutarQR("PAGINA_DEL", arrParam);
    }

    /// <summary>
    /// Procedimiento de Acceso a Datos para listar todos lo registros
    /// </summary>
    /// <param name="c"></param>
    /// <param name="cn"></param>
    /// <returns>DataReader</returns>
    public OracleDataReader Gets(OracleConnection cn, BE_PAGINA c)
    {
        OracleParameter[] arrParam = new OracleParameter[1];
        arrParam[0] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_PAGINA.Gets", arrParam);
    }
    public OracleDataReader GetsActivo(OracleConnection cn, BE_PAGINA c)
    {
        OracleParameter[] arrParam = new OracleParameter[1];
        arrParam[0] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_PAGINA.GetsActivo", arrParam);
    }

    /// <summary>
    /// Procedimiento de Acceso a Datos para listar un registro por su Codigo Unico (Primary Key)
    /// </summary>
    /// <param name="c">Parametros con los criterios de busqueda</param>
    /// <param name="cn"></param>
    /// <returns>Retorna un registro (DataReader)</returns>
    public OracleDataReader Get(OracleConnection cn, BE_PAGINA c)
    {
        OracleParameter[] arrParam = new OracleParameter[1];
        arrParam[0] = new OracleParameter("IDPAGINA", OracleDbType.Int32);
        arrParam[0].Value = c.IDPAGINA;
        arrParam[1] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "PKG_PAGINA.Get", arrParam);
    }

}