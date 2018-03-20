public class CO_Constante
{
    //Constante EStado Inscripcion Organizacion Politica
    public static readonly string EstadoInscripcionOPInscrito = "04";
    public static readonly string EstadoInscripcionOPCancelado = "26";
    //Constante EStado Inscripcion Organizacion Politica

    public static readonly string VariableGlobalSession = "GPSTraker";
    public static readonly string VariableGlobalMensaje = "pizarroXXX";
   
    public static readonly string VariableGlobalCapcha = "ServidorCaptcha";
    

    //"dd/MM/yyyy HH:mm:tt";
    //"dd/MM/yyyy hh:mm:ss tt" site.js
    public static readonly string formatoFecha = "dd/MM/yyyy HH:mm:ss";
    //public static readonly string formatoFechaBD = "dd/MM/yyyy";
    public static readonly string formatoFechaHTML5 = "yyyy-MM-dd";
    // EXITO = 1, INFORMACION = 2, ADVERTENCIA = 3, PELIGRO = 4

    public static readonly string menRegistroModificacion = "Se registró las modificaciones";

    public static readonly string menExito = "Se realizo los cambios correctamente";
    public static readonly string menInformacion = "Se esta procesando la información";
    public static readonly string menAdvertencia = "Tenga precaución al registrar";
    public static readonly string menPeligro = "Existe errores";

   
    public static string msgExito(string msg=null)
    {
        return new BE_MENSAJE(null, (msg.EsNulo() ? menExito : msg), enumTipoMensaje.Exito).Serializar();
    }

    public static string msgInformacion(string msg = null)
    {
        return new BE_MENSAJE(null, (msg.EsNulo() ? menInformacion : msg), enumTipoMensaje.Informacion).Serializar();
    }
    public static string msgAdvertencia(string msg = null)
    {
        return new BE_MENSAJE(null, (msg.EsNulo() ? menAdvertencia : msg), enumTipoMensaje.Advertencia).Serializar();
    }

    public static string msgPeligro(string msg = null)
    {
        return new BE_MENSAJE(null, (msg.EsNulo() ? menPeligro : msg), enumTipoMensaje.Peligro).Serializar();
    }

    public static readonly string menMuestraRegistro = "Se visualiza el registro";
    public static readonly string menNoMuestraRegistro = "No se encontro el registro";
    public static readonly string menMuestranRegistros = "Se vizualizan los registros";
    public static readonly string menRegistroElimino = "Se eliminó el registro";

    public static readonly string menSeleccionHtmlSelect = "-Seleccionar-";

    //public static readonly string KEY = "F184B08F-C81C-45F6-A57F-5ABD9991F28F";
    public static readonly string KEY = "F0CD66FB-0C83-43c6-8921-901412BABCE1";

    //"../../Documentos/" + _Cod_OP.ToString + "/Estatutos/"

    //Rutas
    public static readonly string RutaVistaMensaje = "~/Views/Manage/Mensaje.cshtml";//Ruta de la vista del mensaje al usuario


    public static readonly string RutaCarpetaTemporal = "~/App_Data/Temporal";
    public static readonly string RutaDocumento = "~/App_Data/Documento";    
    public static readonly string RutaAsiento = string.Concat(RutaDocumento , "/{0}/Asiento");
    public static readonly string RutaConstanciaOrganizacionPolitica = string.Concat(RutaDocumento, "/{0}/Const_OP"); 
    public static readonly string RutaDBF = string.Concat(RutaDocumento, "/{0}/DBF");  
    public static readonly string RutaEstatuto = string.Concat(RutaDocumento, "/{0}/Estatutos"); 
    public static readonly string RutaResolucion = string.Concat(RutaDocumento, "/{0}/Resoluciones"); 
    public static readonly string RutaSintesis = string.Concat(RutaDocumento, "/{0}/Sintesis"); 
    public static readonly string RutaVerificacionFirma = string.Concat(RutaDocumento, "/{0}/VF");   


    //Fin Rutas

}