using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SROP.Controllers.api
{
    
    public partial  class ManageApiController : BaseApiController
    {

        //public async Task<JsonResult<BE_Abogado>> GetCapchaLg()
        //{
        //    return await Task.Run(() =>
        //    {
        //        ServidorCaptcha Captcha = new ServidorCaptcha();
        //        Session["ServidorCaptcha"] = Captcha.GenerarRandom();
        //        Captcha.Generar(Session["ServidorCaptcha"].Text(), 200, 40, "Arial");
        //        using (var ms = new MemoryStream())
        //        {
        //            Captcha.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            return Json(new { base64imagen = Convert.ToBase64String(ms.ToArray()) }, JsonRequestBehavior.AllowGet);
        //        }
        //    });
        //}

        //public async Task<JsonResult<BE_Abogado>> SaveEvaluationFile(EvaluationFileDetails FileData)
        //{
        //    IEnumerable<string> headerValues = Request.Headers.GetValues("oldFileName");
        //    var oldFileName = headerValues.FirstOrDefault();
        //    IEnumerable<string> headerValues1 = Request.Headers.GetValues("identifier");
        //    var newFileName = headerValues1.FirstOrDefault();

        //    try
        //    {
        //        foreach (string file in FileData.images)
        //        {
        //            HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Json("Upload failed");
        //    }

        //    return Json("File uploaded successfully");
        //}

        // generic file post method - use in MVC or WebAPI

        [HttpPost]
        public IHttpActionResult UploadFile()
        {
            foreach ( string file in HttpContext.Current.Request.Files)
            {
                var FileDataContent = HttpContext.Current.Request.Files[file];
                //var FileDataContent = file;
               
                if (FileDataContent != null && FileDataContent.ContentLength > 0)
                {
                    FileUpLoad Archivo = HttpContext.Current.Request.Form["JSONSTRING"].DesSerializar<FileUpLoad>();
                    //// take the input stream, and save it to a temp folder using the original file.part name posted
                    var stream = FileDataContent.InputStream;
                    var fileName = Path.GetFileName(FileDataContent.FileName);
                    //if (Archivo.)

                    //var UploadPath = System.Web.Hosting.HostingEnvironment.MapPath(CO_Constante.RutaDocumento);
                    var UploadPath = Archivo.RutaCarpeta();
                    //if (Archivo.ENVIARA == TIPOTABLA.ENVIARA.CarpetaTemporal) { UploadPath = System.Web.Hosting.HostingEnvironment.MapPath(CO_Constante.RutaCarpetaTemporal);}

                    Directory.CreateDirectory(UploadPath);

                    string path = Path.Combine(UploadPath, fileName);
                    try
                    {
                        if (File.Exists(path))
                            File.Delete(path);
                        using (var fileStream = File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        // Once the file part is saved, see if we have enough to merge it
                       
                        FileUpLoad UT = new FileUpLoad();
                        bool res = UT.MergeFile(path);
                        if (res == true)
                        {
                            //Archivo.FormatearNombreDeArchivo(UT.baseFileName); UT.baseFileName = null;
                            //FileStream fs = new FileStream(UT.baseFileName, FileMode.Open, FileAccess.Read);
                            //long filesize = fs.Length;
                            //Archivo.BLARCHIVO = new byte[Convert.ToInt32(fs.Length - 1) + 1];
                            //fs.Read(Archivo.BLARCHIVO, 0, Convert.ToInt32(filesize));
                            //fs.Close();
                            
                            Archivo.TXARCHIVORUTACOMPLETA = UT.baseFileName; UT.baseFileName = null;
                            Archivo = ValidaArchivo(Archivo);

                            //if (Archivo.ENVIARA != TIPOTABLA.ENVIARA.BaseDatos) { File.Delete(UT.baseFileName); }; //Eliminar el archivo//
                            if (ModelState.IsValid)
                            {
                                if (Archivo.TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Simbolo)
                                {
                                    if (Archivo.ENVIARA == TIPOTABLA.ENVIARA.CarpetaDocumento || Archivo.ENVIARA == TIPOTABLA.ENVIARA.CarpetaTemporal)
                                    {
                                        return Json(new
                                        {
                                            success = true,
                                            Message = CO_Constante.msgExito("Archivo seleccionado"),
                                            EnviarA = Archivo.ENVIARA == TIPOTABLA.ENVIARA.CarpetaDocumento ? "CarpetaDocumento" : "CarpetaTemporal",
                                            ArchivoRutaCompleta = Archivo.TXARCHIVORUTACOMPLETA,
                                            ArchivoNombre = Archivo.TXARCHIVONOMBRE,
                                            ArchivoExtension = Archivo.TXARCHIVOEXTENSION
                                        });
                                    }
                                }   
                                else if(Archivo.TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Simbolo)
                                {
                                    GrabaSimbolo(Archivo);
                                    return Json(new
                                    {
                                        success = true,
                                        Message = CO_Constante.msgExito(),
                                        type="blob"
                                    });
                                }
                                else if (Archivo.TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Resolucion)
                                {


                                }
                                else if (Archivo.TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Estatuto)
                                {
                                    GrabaEstatuto(Archivo);
                                    return Json(new
                                    {
                                        success = true,
                                        Message = CO_Constante.msgExito(),
                                        type = "file",
                                        data= Archivo
                                    });
                                }
                            }
                            else
                            {
                                //ec.Request.CreateErrorResponse(HttpStatusCode.BadRequest, m.Serializar());                                
                                return Json(new
                                {
                                    success = true,
                                    Message = ModelState.AllErrors() //.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).First())
                                });
                            }

                            //System.IO.File.Delete(TXRUTAARCHIVOCARGADO);
                        }
                    }
                    catch (IOException ex)
                    { 
                        throw ex;
                    }
                }
            }
            return Json(new
            {
                success = false,
                Message = CO_Constante.msgInformacion()
            });
        }

        private FileUpLoad ValidaArchivo(FileUpLoad ARCHIVOENPROCESO)        {

            ARCHIVOENPROCESO.FormatearNombreDeArchivo(ARCHIVOENPROCESO.TXARCHIVORUTACOMPLETA);

            if (ARCHIVOENPROCESO.accept.EsNulo())
            {
                msgAdvertencia("No se puede validar el archivo");
            }
            else
            {
                if (ARCHIVOENPROCESO.accept.IndexOf(ARCHIVOENPROCESO.TXARCHIVOEXTENSION) == -1)
                {
                    ARCHIVOENPROCESO.TXARCHIVOEXTENSION = null;
                    ARCHIVOENPROCESO.TXARCHIVONOMBRE = null;
                    msgAdvertencia("Formato del archivo adjunto No valido");
                }
            }
            return ARCHIVOENPROCESO;
        }


    }
}