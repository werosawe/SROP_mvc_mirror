using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

[Serializable()]
[DataContract()]
public enum enumTabExpediente
{
    [EnumMember()] Ninguno = 0,
    [EnumMember()] Expediente = 1,
    [EnumMember()] Etapa = 2,
    [EnumMember()] Sintesis = 3,
    [EnumMember()] Estatuto = 4,
    [EnumMember()] Resolucion = 5,
    [EnumMember()] Asiento = 6,
    [EnumMember()] ModificacionPartida = 7
}

[Serializable()]
[DataContract()]
public enum enumEstadoPagina
{
    [EnumMember()] Ninguno = 1,
    [EnumMember()] Nuevo = 2,
    [EnumMember()] Edicion = 3,
    [EnumMember()] Preliminar = 4,
    [EnumMember()] Insertar = 5
}

[Serializable()]
[DataContract()]
public enum enumTipoMensaje
{
    [EnumMember()] Exito = 1,
    [EnumMember()] Informacion = 2,
    [EnumMember()] Advertencia = 3,
    [EnumMember()] Peligro = 4
}

public static class TIPOTABLA
{

    public static readonly int TipoLibro = 1;
    public static readonly int TipoZona = 2;
    public static readonly int TipoVia = 3;
    public static readonly int TipoArchivo = 4;
    
    public static class TIPOARCHIVODOCUMENTO
    {      
        public static readonly int Simbolo = 1;     
        public static readonly int Asiento = 2;
        public static readonly int ConstanciaOrganizacionPolitica = 3;
        public static readonly int DBF = 4;
        public static readonly int Estatuto = 5;
        public static readonly int Resolucion = 6;
        public static readonly int Sintesis = 7;
        public static readonly int VerificacionFirma = 3;


        //public static readonly string RutaCarpetaTemporal = "~/App_Data/Temporal";
        //public static readonly string RutaDocumento = "~/App_Data/Documento";
        //public static readonly string RutaAsiento = string.Concat(RutaDocumento, "/{0}/Asiento");
        //public static readonly string RutaConstanciaOrganizacionPolitica = string.Concat(RutaDocumento, "/{0}/Const_OP");
        //public static readonly string RutaDBF = string.Concat(RutaDocumento, "/{0}/DBF");
        //public static readonly string RutaEstatuto = string.Concat(RutaDocumento, "/{0}/Estatutos");
        //public static readonly string RutaResolucion = string.Concat(RutaDocumento, "/{0}/Resoluciones");
        //public static readonly string RutaSintesis = string.Concat(RutaDocumento, "/{0}/Sintesis");
        //public static readonly string RutaVerificacionFirma = string.Concat(RutaDocumento, "/{0}/VF");

    }


    public static class ENVIARA
    {
        public static readonly int CarpetaDocumento = 1;
        public static readonly int CarpetaTemporal = 2;
        public static readonly int BaseDatos= 3;
    }

}