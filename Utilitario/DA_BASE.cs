using System;
using Utilitario;

public class DA_BASE : IDisposable
{
    private Oracle_Entity _ORACLEHELPER;  
    //CLAVE PARA LA ENCRIPTAR/DESCENCRIPTAR LA CADENA DE CONEXION
    //public const string KEY = "F0CD66FB-0C83-43c6-8921-901412BABCE1";

    private string _TX_ESQUEMA = "ORGPOLV2";
      
    public string TX_ESQUEMA
    {
        get { return Encriptar_Desencriptar.Desencriptar_CN(_TX_ESQUEMA, CO_Constante.KEY); }
    }

    public Oracle_Entity ORACLEHELPER
    {
        get { return _ORACLEHELPER; }
        set { _ORACLEHELPER = value; }
    }


    private bool disposedValue = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {

                _ORACLEHELPER.Dispose();
                _ORACLEHELPER = null;
            }

            // TODO: Liberar su propio estado (objetos no administrados).
            // TODO: Establecer campos grandes como Null.
        }
        this.disposedValue = true;
    }


    // Visual Basic agreg� este c�digo para implementar correctamente el modelo descartable.
    public void Dispose()
    {
        // No cambie este c�digo. Coloque el c�digo de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(true);
        GC.SuppressFinalize(this);
    }



    public DA_BASE()
    {
        _ORACLEHELPER = new Oracle_Entity(_TX_ESQUEMA, CO_Constante.KEY);
    }


}

