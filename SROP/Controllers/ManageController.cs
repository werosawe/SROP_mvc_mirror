using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;

using System.Configuration;
using System.Net;

namespace SROP.Controllers
{
    //[Authorize]
    public partial class ManageController : Controller
    {

        public ActionResult Mensaje()
        {
            List<BE_MENSAJE> r = new List<BE_MENSAJE>();
           
            //foreach (var item in ViewData.ModelState)
            //{
            //    if (item.Value.Errors.Any())
            //    {
            //        foreach (ModelError e in item.Value.Errors)
            //        {
            //            BE_MENSAJE i = e.ErrorMessage.DesSerializar<BE_MENSAJE>();
            //            r.Add(i);
            //            //if (item.Key == enumTipoMensaje.Exito.ToString()) { TXTIPOERROR = "success"; }
            //            //if (item.Key == enumTipoMensaje.Informacion.ToString()) { TXTIPOERROR = "info"; }
            //            //if (item.Key == enumTipoMensaje.Advertencia.ToString()) { TXTIPOERROR = "warning"; }
            //            //if (item.Key == enumTipoMensaje.Peligro.ToString()) { TXTIPOERROR = "danger"; }

            //            //s.Append("<div class='alert alert-" + TXTIPOERROR + " alert-dismissible alert-icon-left fade in mb-2' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button>");
            //            //s.Append(e.ErrorMessage);
            //            //s.Append("</div>");
            //        }
            //    }
            //}
            
          

        //        public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    var modelState = actionContext.ModelState;

            //    if (!modelState.IsValid)
            //        actionContext.Response = actionContext.Request
            //             .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            //}

            if (Session[CO_Constante.VariableGlobalMensaje] != null) {
                r = Session[CO_Constante.VariableGlobalMensaje].Text().DesSerializarLista<BE_MENSAJE>();
                Session[CO_Constante.VariableGlobalMensaje] = null;
            }
            return View(r);
        }

        public ActionResult ClientUpload(FileUpLoad c )
        {            
            BL_Tipo b = new BL_Tipo();
            try
            {
                BE_Tipo i = b.Get(new BE_Tipo() { IDGRUPO = TIPOTABLA.TipoArchivo, IDTIPO = c.TIPOARCHIVODOCUMENTO });
                if (i != null)
                {
                    c.accept = i.TXVALOR;
                }
                //    multiple: 0,
                //TipoArchivo: @TIPOTABLA.TIPOARCHIVODOCUMENTO.Simbolo,

                //ESTADOPAGINA: '@enumEstadoPagina.Edicion',
                //Cod_OP: @Model.Cod_OP,
                //ProcesoTerminado: 'CargarSimbolo'

                c.JSONSTRING = c.GetFieldJson("accept", "multiple", "TIPOARCHIVODOCUMENTO", "ENVIARA", "TerminateFunction");
                //c =  get GetFieldJson c.Serializar();
                return View(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }

        // generic file post method - use in MVC or WebAPI
        //[HttpPost]
        //public HttpResponseMessage UploadFile(FileUpLoad c)
        //{
        //    foreach (string file in Request.Files)
        //    {
        //        var FileDataContent = Request.Files[file];
        //        if (FileDataContent != null && FileDataContent.ContentLength > 0)
        //        {
        //            // take the input stream, and save it to a temp folder using the original file.part name posted
        //            Stream stream = FileDataContent.InputStream;
        //            string fileName = Path.GetFileName(FileDataContent.FileName);
        //            string UploadPath = Server.MapPath("~/App_Data/uploads");
        //            Directory.CreateDirectory(UploadPath);
        //            string path = Path.Combine(UploadPath, fileName);
        //            try
        //            {
        //                if (System.IO.File.Exists(path))
        //                    System.IO.File.Delete(path);
        //                using (FileStream fileStream = System.IO.File.Create(path))
        //                {
        //                    stream.CopyTo(fileStream);
        //                }
        //                // Once the file part is saved, see if we have enough to merge it
        //                FileUpLoad UT = new FileUpLoad();
        //                bool res =  UT.MergeFile(path);
        //                if (res == true)
        //                {
        //                    FileUpLoad i = c.CAMPOSJSON.DesSerializar<FileUpLoad>();
        //                    FileStream fs = new FileStream(UT.baseFileName, FileMode.Open, FileAccess.Read);
        //                    long filesize = fs.Length;
        //                    i.BLARCHIVO = new byte[Convert.ToInt32(fs.Length - 1) + 1];
        //                    fs.Read(i.BLARCHIVO, 0, Convert.ToInt32(filesize));
        //                    fs.Close();
        //                    i.TXARCHIVORUTACOMPLETA = UT.baseFileName.Mayuscula(); UT.baseFileName = null;
        //                    i = fValidaArchivo(i);
        //                    if (ModeloValido)
        //                    {
        //                        if (c.TipoArchivo == TipoTabla.TipoArchivo_.Simbolo)
        //                        {
        //                            GrabaSimbolo(i);
        //                        }
        //                        else if (c.TipoArchivo == TipoTabla.TipoArchivo_.Resolucion)
        //                        {


        //                        }
        //                    }
        //                    else {
        //                        //ec.Request.CreateErrorResponse(HttpStatusCode.BadRequest, m.Serializar());
                                                             
        //                        return new HttpResponseMessage()
        //                        {
        //                            StatusCode = System.Net.HttpStatusCode.OK,
        //                            Content = new StringContent("File uploaded.")
        //                        };
        //                    }
                           
        //                    //System.IO.File.Delete(TXRUTAARCHIVOCARGADO);
        //                }
        //            }
        //            catch (IOException ex)
        //            {
        //                throw ex;
        //                // handle
        //            }
        //        }
        //    }
        //    return new HttpResponseMessage()
        //    {
        //        StatusCode = System.Net.HttpStatusCode.OK,
        //        Content = new StringContent("File uploaded.")
        //    };
        //}

        //private FileUpLoad fValidaArchivo(FileUpLoad ARCHIVOENPROCESO){
        //    string TXARCHIVONOMBRE = null;
        //    string TXARCHIVOEXTENSION = ARCHIVOENPROCESO.TXARCHIVORUTACOMPLETA.ToString().Substring(ARCHIVOENPROCESO.TXARCHIVORUTACOMPLETA.ToString().Length - 4, 4);
        //    int NUINICIO = ARCHIVOENPROCESO.TXARCHIVORUTACOMPLETA.ToString().LastIndexOf("\\") + 1;
        //    int NUFINAL = ARCHIVOENPROCESO.TXARCHIVORUTACOMPLETA.ToString().LastIndexOf(".");
        //    TXARCHIVONOMBRE = ARCHIVOENPROCESO.TXARCHIVORUTACOMPLETA.Substring(NUINICIO, NUFINAL - NUINICIO);
        //    TXARCHIVONOMBRE = TXARCHIVONOMBRE.RemoveDiacritics();
        //    TXARCHIVONOMBRE = TXARCHIVONOMBRE.RestringeASCII(40);

        //    TXARCHIVONOMBRE = TXARCHIVONOMBRE.Mayuscula();
        //    TXARCHIVOEXTENSION = TXARCHIVOEXTENSION.Replace(".", "").Mayuscula();
        //    if (ARCHIVOENPROCESO.accept.EsNulo())
        //    {
        //        msgAdvertencia("No se puede validar el archivo");
        //    }
        //    else
        //    {
        //        if (ARCHIVOENPROCESO.accept.IndexOf(TXARCHIVOEXTENSION) > -1)
        //        {
        //            ARCHIVOENPROCESO.TXARCHIVOEXTENSION = TXARCHIVOEXTENSION;
        //            ARCHIVOENPROCESO.TXARCHIVONOMBRE = TXARCHIVONOMBRE;
        //        }
        //        else
        //        {
        //            msgAdvertencia("Formato del archivo adjunto No valido");
        //        }
        //    }
        //    return ARCHIVOENPROCESO;
        //}

        //public static string fTipoArchivo(string TXFORMATO)
        //{
        //    if (TXFORMATO.NoNulo())
        //    {
        //        int NUINICIO = TXFORMATO.ToString().LastIndexOf(".");
        //        if (NUINICIO > -1)
        //        {
        //            TXFORMATO = TXFORMATO.ToString().Substring(NUINICIO);
        //            TXFORMATO = TXFORMATO.Text().Mayuscula().Replace(".", "");
        //        }
        //    }
        //    switch (TXFORMATO)
        //    {
        //        case "JPG":
        //            return "image/jpg";
        //        case "JPEG":
        //            return "image/jpeg";
        //        case "TIF":
        //            return "image/tiff";
        //        case "BMP":
        //            return "image/bmp";
        //        case "PNG":
        //            return "image/png";
        //        case "GIF":
        //            return "image/gif";
        //        case "CSS":
        //            return "text/css";
        //        case "PDF":
        //            return "application/pdf";
        //        case "TXT":
        //            return "text/plain";
        //        case "HTML":
        //            return "text/html";
        //        case "RTF":
        //            return "application/rtf";
        //        case "XLS":
        //            return "application/vnd.ms-excel";
        //        case "DBF":
        //            return "application/vnd.ms-excel";
        //        case "XLSX":
        //            return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        case "DOC":
        //            return "application/msword";
        //        case "DOCX":
        //            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        //        case "PPT":
        //            return "application/vnd.ms-powerpoint";
        //        case "PPS":
        //            return "application/vnd.ms-powerpoint";
        //        case "PPTX":
        //            return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        //        case "PPSX":
        //            return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        //        //case "PPSX":
        //        //    return "application/vnd.openxmlformats-officedocument.presentationml.slideshow";
        //        case "MDB":
        //            return "application/vnd.ms-access";
        //        case "MDBX":
        //            return "application/vnd.ms-access";
        //        case "ZIP":
        //            return "application/zip";
        //        default:
        //            return "application/octet-stream";
        //    }
        //}        

        public async Task<ActionResult> GetCapchaLg()
        {
            return await Task.Run(() =>
            {
                ServidorCaptcha Captcha = new ServidorCaptcha();
                Session[CO_Constante.VariableGlobalCapcha] = Captcha.GenerarRandom();
                Captcha.Generar(Session[CO_Constante.VariableGlobalCapcha].Text(), 200, 40, "Arial");
                using (var ms = new MemoryStream())
                {
                    Captcha.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return Json(new {  base64imagen = Convert.ToBase64String(ms.ToArray()), TXCAPCHA = Session[CO_Constante.VariableGlobalCapcha] }, JsonRequestBehavior.AllowGet);
                }
            });
        }

        //public PartialViewResult GetImageTmp(FileUpLoad c)               
        public async Task<ActionResult> GetImageTmp(FileUpLoad c)              
        {
            //FileStream fs2 = new FileStream(string.Concat(Server.MapPath(CO_Constante.RutaUploadTemporal), "/", c.FileName), FileMode.Open, FileAccess.Read);
            //var type = Funciones.fTipoArchivo(c.FileName);  //Path.GetExtension(fs2.Name);
            //return PartialView(c);
            return await Task.Run(() =>
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(string.Concat(CO_Constante.RutaCarpetaTemporal.GetPath(), "/", c.FileName), FileMode.Open, FileAccess.Read);
                    var type = Funciones.fTipoArchivo(c.FileName);
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        return File(ms.ToArray(), type);
                    }
                }
                finally
                {
                    fs.Close(); fs = null;
                }
            });
        }



    }
}