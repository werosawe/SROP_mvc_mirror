using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;
using System.Linq;
/// Project	 : BL
/// Class	 : BL_PAGINA
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
public partial class BL_PAGINA : BL_BASE
{
    private DA_PAGINA data;
    /// <summary>
    ///   Procedimiento de Negocio para añadir un registro
    /// </summary>
    /// <param name="c"></param>
    /// <returns>int</returns>
    public int ADD(BE_PAGINA c)
    {
        return data.ADD(c);
    }

    /// <summary>
    ///   Procedimiento de Negocio para Editar un Registro
    /// </summary>
    /// <param name="c"></param>
    public void EDIT(BE_PAGINA c)
    {
        data.EDIT(null, c);
    }

    /// <summary>
    /// Procedimiento de Negocio para cambiar el estado de un Registro
    /// </summary>
    /// <param name="c"></param>
    public void EDIT_EST(BE_PAGINA c)
    {
        data.EDIT_EST(c);
    }

    /// <summary>
    /// Procedimiento de Negocio para eliminar un Registro
    /// </summary>
    /// <param name="c"></param>
    public void DEL(BE_PAGINA c)
    {
        data.DEL(c);
    }

    /// <summary>
    /// Procedimiento de Negocio para listar todos lo registros
    /// </summary>
    /// <param name="c"></param>
    public List<BE_PAGINA> Gets(BE_PAGINA c)
    {
        List<BE_PAGINA> r = new List<BE_PAGINA>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Gets(cn, c);         
            while (dr.Read())
            {
                BE_PAGINA i = new BE_PAGINA();
                i.IDAREA = dr.Num("IDAREA");
                i.NUORDEN = dr.Num("NUORDEN");
                i.TXTITULOFLOTANTE = dr.Text("TXTITULOFLOTANTE");               
                i.IDPAGINAPADRE = dr.Num("IDPAGINAPADRE");
                i.TXCONTROLADOR = dr.Text("TXCONTROLADOR");
                i.TXACCION = dr.Text("TXACCION");
                i.TXAREA = dr.Text("TXAREA");
                i.IDPAGINA = dr.Num("IDPAGINA");
                i.TXROL = dr.Text("TXROL");
                i.TXTITULO = dr.Text("TXTITULO");
                i.TXAREA = dr.Text("TXAREA");
                i.TXAREADESCRIPCION = dr.Text("TXAREADESCRIPCION");
                i.QTPADRES = dr.Num("QTPADRES");
                r.Add(i);
            }
            pCerrarDr(cn, dr);
            return r;
    }

    public List<BE_PAGINA> GetsActivo(BE_PAGINA c)
    {
        List<BE_PAGINA> r = new List<BE_PAGINA>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.GetsActivo(cn, c);
            while (dr.Read())
            {
                BE_PAGINA i = new BE_PAGINA();
                i.IDAREA = dr.Num("IDAREA");
                i.NUORDEN = dr.Num("NUORDEN");
                i.TXTITULOFLOTANTE = dr.Text("TXTITULOFLOTANTE");
                i.IDPAGINAPADRE = dr.Num("IDPAGINAPADRE");
                i.TXCONTROLADOR = dr.Text("TXCONTROLADOR");
                i.TXACCION = dr.Text("TXACCION");
                i.TXAREA = dr.Text("TXAREA");
                i.IDPAGINA = dr.Num("IDPAGINA");
                i.TXROL = dr.Text("TXROL");
                i.TXTITULO = dr.Text("TXTITULO");
                i.TXAREA = dr.Text("TXAREA");
                i.TXAREADESCRIPCION = dr.Text("TXAREADESCRIPCION");
                i.QTPADRES = dr.Num("QTPADRES");
                r.Add(i);
            }
            pCerrarDr(cn, dr);
            return r;        
    }

    /// <summary>
    /// Procedimiento de Negocio para listar un registro por su primary key
    /// </summary>
    /// <param name="c">Parametros con los criterios de busqueda</param>
    /// <returns>Retorna una Objeto</returns>
    public BE_PAGINA Get(BE_PAGINA c)
    {
        BE_PAGINA i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Get(cn, c);
            if (dr.Read())
            {
                i.IDAREA = dr.Num("IDAREA");
                i.NUORDEN = dr.Num("NUORDEN");
                i.TXTITULOFLOTANTE = dr.Text("TXTITULOFLOTANTE");
                i.IDPAGINAPADRE = dr.Num("IDPAGINAPADRE");
                i.TXCONTROLADOR = dr.Text("TXCONTROLADOR");
                i.TXACCION = dr.Text("TXACCION");
                i.IDPAGINA = dr.Num("IDPAGINA");
                i.TXAREA = dr.Text("TXAREA");
                i.TXROL = dr.Text("TXROL");
                i.TXTITULO = dr.Text("TXTITULO");
                i.TXAREA = dr.Text("TXAREA");
                i.TXAREADESCRIPCION = dr.Text("TXAREADESCRIPCION");
                i.QTPADRES = dr.Num("QTPADRES");
            }
        pCerrarDr(cn, dr);
        return i;
    }

    public BL_PAGINA()
    {
        data = new DA_PAGINA();
    }
    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            data.Dispose(); data = null;
        }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BL_PAGINA() { Dispose(false); }
}