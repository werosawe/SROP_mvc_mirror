using System;
using Oracle.DataAccess.Client;
public class BL_BASE : IDisposable
{
    // PARA DETECTAR LLAMADAS REDUNDANTES
    private DA_BASE _DA_BASE;

    private bool disposedValue = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {

            if (disposing)
            {
                _DA_BASE.Dispose();
                _DA_BASE = null;
                // TODO: Liberar otro estado (objetos administrados).
            }

            // TODO: Liberar su propio estado (objetos no administrados).
            // TODO: Establecer campos grandes como Null.
        }
        this.disposedValue = true;
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    public BL_BASE()
    {
        _DA_BASE = new DA_BASE();
    }

    public string TX_ESQUEMA
    {
        get { return _DA_BASE.TX_ESQUEMA; }
    }

    public void pCerrarDr(OracleConnection cn, OracleDataReader dr)
    {
        if (dr != null)
        {
            if (dr.IsClosed == false)
            {
                dr.Close();
            }
            dr.Dispose();
            dr = null;
        }
        cn.Close();
        cn.Dispose();
        cn = null;
    }
}

