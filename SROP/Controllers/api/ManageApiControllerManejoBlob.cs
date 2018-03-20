using System;
using System.IO;

namespace SROP.Controllers.api
{
    //[Authorize]
    public partial class ManageApiController
    {
  

        public void GrabaSimbolo(FileUpLoad c)
        {
            BL_OP b = new BL_OP();
            BE_OP i = new BE_OP();
            try
            {
                //i.Cod_OP = c.Cod_OP;
                i.Img_Simbolo_Op = c.BLARCHIVO;                
                b.GrabaSimbolo(i);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                b.Dispose(); b = null;
                i.Dispose(); i = null;
            }
        }
        //GrabaEstatuto

        public void GrabaEstatuto(FileUpLoad c)
        {
            //BL_OP b = new BL_OP();
            //BE_OP i = new BE_OP();
            //try
            //{
            //    i.Cod_OP = c.Cod_OP;
            //    i.Img_Simbolo_Op = c.BLARCHIVO;
            //    b.GrabaSimbolo(i);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    b.Dispose(); b = null;
            //    i.Dispose(); i = null;
            //}

        }

    }
}


public class GrabaBlobABaseDatosDesdeCarpetaTemporal : IDisposable
{
    public void Simbolo(BE_OP c)
    {
        //FileStream fs = null;
        //FileUpLoad Archivo = new FileUpLoad();
        BL_OP b = new BL_OP();
        try
        {
            c.ENVIARA = TIPOTABLA.ENVIARA.BaseDatos;
            c.TIPOARCHIVODOCUMENTO = TIPOTABLA.TIPOARCHIVODOCUMENTO.Simbolo;
            c.FormatearNombreDeArchivo(string.Concat(c.RutaCarpeta(),"/", c.TXARCHIVONOMBRE));            
            //fs = new FileStream(string.Concat(Server.MapPath(CO_Constante.RutaUploadTemporal), "/", c.FileName), FileMode.Open, FileAccess.Read);
            //fs = new FileStream(Archivo.TXARCHIVORUTACOMPLETA, FileMode.Open, FileAccess.Read);
            //long filesize = fs.Length;
            //Archivo.BLARCHIVO = new byte[Convert.ToInt32(fs.Length - 1) + 1];
            //fs.Read(Archivo.BLARCHIVO, 0, Convert.ToInt32(filesize));
            //fs.Close();

            //i.Cod_OP = c.Cod_OP;

            //i.BLARCHIVO = c.BLARCHIVO;
            b.GrabaSimbolo(c);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            b.Dispose(); b = null;
            //i.Dispose(); i = null;
        }
    }

    private bool disposedValue = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {

            if (disposing)
            {
              
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
}