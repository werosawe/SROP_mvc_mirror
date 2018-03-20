using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

[Serializable()]
[DataContract()]
public class BE_BASE :  IDisposable
{
    
    [DataMember(EmitDefaultValue = false, Name = "IDESTREG")] public int IDESTREG { get; set; }

    //Manejo de Archivos
    [DataMember(EmitDefaultValue = false, Name = "TIPOARCHIVODOCUMENTO")] public int TIPOARCHIVODOCUMENTO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ENVIARA")] public int ENVIARA { get; set; }
   

    public string RutaCarpeta(int CODOP = 0)
    {
        if (ENVIARA == TIPOTABLA.ENVIARA.CarpetaTemporal || ENVIARA == TIPOTABLA.ENVIARA.BaseDatos)
        {
            return CO_Constante.RutaCarpetaTemporal.GetPath();
        }
        else if (ENVIARA == TIPOTABLA.ENVIARA.CarpetaDocumento)
        {
            if (TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Asiento)
            {
                return string.Format(CO_Constante.RutaAsiento, CODOP).GetPath();
            }
            else if (TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.ConstanciaOrganizacionPolitica)
            {
                return string.Format(CO_Constante.RutaConstanciaOrganizacionPolitica, CODOP).GetPath();
            }
            else if (TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.DBF)
            {
                return string.Format(CO_Constante.RutaDBF, CODOP).GetPath();
            }
            else if (TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Estatuto)
            {
                return string.Format(CO_Constante.RutaEstatuto, CODOP).GetPath();
            }
            else if (TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Resolucion)
            {
                return string.Format(CO_Constante.RutaResolucion, CODOP).GetPath();
            }
            else if (TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.Sintesis)
            {
                return string.Format(CO_Constante.RutaSintesis, CODOP).GetPath();
            }
            else if (TIPOARCHIVODOCUMENTO == TIPOTABLA.TIPOARCHIVODOCUMENTO.VerificacionFirma)
            {
                return string.Format(CO_Constante.RutaVerificacionFirma, CODOP).GetPath();
            }

        }
        //      public static readonly string RutaCarpetaTemporal = "~/App_Data/Temporal";
        //public static readonly string RutaDocumento = "~/App_Data/Documento";
        //public static readonly string RutaAsiento = string.Concat(RutaDocumento, "/{0}/Asiento");
        //public static readonly string RutaConstanciaOrganizacionPolitica = string.Concat(RutaDocumento, "/{0}/Const_OP");
        //public static readonly string RutaDBF = string.Concat(RutaDocumento, "/{0}/DBF");
        //public static readonly string RutaEstatuto = string.Concat(RutaDocumento, "/{0}/Estatutos");
        //public static readonly string RutaResolucion = string.Concat(RutaDocumento, "/{0}/Resoluciones");
        //public static readonly string RutaSintesis = string.Concat(RutaDocumento, "/{0}/Sintesis");
        //public static readonly string RutaVerificacionFirma = string.Concat(RutaDocumento, "/{0}/VF");   
        return null;
    }

    //Fin Manejo de Archivos

    [DataMember(EmitDefaultValue = false, Name = "UBIGEO")] public string UBIGEO { get; set; }

    public string _UBIREGION;
    [DataMember(EmitDefaultValue = false, Name = "UBIREGION")] public string UBIREGION { get { if (_UBIREGION.Num() != 0) { return _UBIREGION; } else { return null; } } set { _UBIREGION = value; } }

    public string _UBIPROVINCIA;
    [DataMember(EmitDefaultValue = false, Name = "UBIPROVINCIA")] public string UBIPROVINCIA { get { if (_UBIPROVINCIA.Num() != 0) { return _UBIPROVINCIA; } else { return null; } } set { _UBIPROVINCIA = value; } }

    public string _UBIDISTRITO;
    [DataMember(EmitDefaultValue = false, Name = "UBIDISTRITO")] public string UBIDISTRITO { get { if (_UBIDISTRITO.Num() != 0) { return _UBIDISTRITO; } else { return null; } } set { _UBIDISTRITO = value; } }


    [DataMember(EmitDefaultValue = false, Name = "TXREGION")] public string TXREGION { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXPROVINCIA")] public string TXPROVINCIA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXDISTRITO")] public string TXDISTRITO { get; set; }

    public string _UBIREGIONDOMLEGAL;
    [DataMember(EmitDefaultValue = false, Name = "UBIREGIONDOMLEGAL")] public string UBIREGIONDOMLEGAL { get { if (_UBIREGIONDOMLEGAL.Num() != 0) { return _UBIREGIONDOMLEGAL; } else { return null; } } set { _UBIREGIONDOMLEGAL = value; } }

    public string _UBIPROVINCIADOMLEGAL;
    [DataMember(EmitDefaultValue = false, Name = "UBIPROVINCIADOMLEGAL")] public string UBIPROVINCIADOMLEGAL { get { if (_UBIPROVINCIADOMLEGAL.Num() != 0) { return _UBIPROVINCIADOMLEGAL; } else { return null; } } set { _UBIPROVINCIADOMLEGAL = value; } }

    public string _UBIDISTRITODOMLEGAL;
    [DataMember(EmitDefaultValue = false, Name = "UBIDISTRITODOMLEGAL")] public string UBIDISTRITODOMLEGAL { get { if (_UBIDISTRITODOMLEGAL.Num() != 0) { return _UBIDISTRITODOMLEGAL; } else { return null; } } set { _UBIDISTRITODOMLEGAL = value; } }
 
    public string _UBIREGIONDOMPROCESAL;
    [DataMember(EmitDefaultValue = false, Name = "UBIREGIONDOMPROCESAL")] public string UBIREGIONDOMPROCESAL { get { if (_UBIREGIONDOMPROCESAL.Num() != 0) { return _UBIREGIONDOMPROCESAL; } else { return null; } } set { _UBIREGIONDOMPROCESAL = value; } }

    public string _UBIPROVINCIADOMPROCESAL;
    [DataMember(EmitDefaultValue = false, Name = "UBIPROVINCIADOMPROCESAL")] public string UBIPROVINCIADOMPROCESAL { get { if (_UBIPROVINCIADOMPROCESAL.Num() != 0) { return _UBIPROVINCIADOMPROCESAL; } else { return null; } } set { _UBIPROVINCIADOMPROCESAL = value; } }
    
    public string _UBIDISTRITODOMPROCESAL;
    [DataMember(EmitDefaultValue = false, Name = "UBIDISTRITODOMPROCESAL")] public string UBIDISTRITODOMPROCESAL { get { if (_UBIDISTRITODOMPROCESAL.Num() != 0) { return _UBIDISTRITODOMPROCESAL; } else { return null; } } set { _UBIDISTRITODOMPROCESAL = value; } }


    [DataMember(EmitDefaultValue = false, Name = "TABEXPEDIENTE")] public enumTabExpediente TABEXPEDIENTE { get; set; }


    [DataMember(EmitDefaultValue = false, Name = "NUPAGINAACTUAL")] public int NUPAGINAACTUAL { get; set; }



    [DataMember(EmitDefaultValue = false, Name = "ESTADOPAGINA")] public enumEstadoPagina ESTADOPAGINA { get; set; }

  

    [DataMember(EmitDefaultValue = false, Name = "Cod_OP")] public int Cod_OP { get; set; }
    [text(0, 0, "Denominación Organización")] [DataMember(EmitDefaultValue = false, Name = "Des_OP")] public string Des_OP { get; set; }
  

    [DataMember(EmitDefaultValue = false, Name = "Cod_Tipo_OP")] public string Cod_Tipo_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tipo_Libro")] public string Tipo_Libro { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Ambito")] public string Cod_Ambito { get; set; }

    


    // Para detectar llamadas redundantes


    private object _FLSIMBOLO;
    [DataMember(EmitDefaultValue = false, Name = "FLSIMBOLO")]
    public object FLSIMBOLO
    {
        get
        {
            if (_FLSIMBOLO == null) { return 0; }
            else
            {
                if (_FLSIMBOLO.NoNulo())
                {
                    if (_FLSIMBOLO.ToString() == "on") { return 1; }
                    else if (_FLSIMBOLO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLSIMBOLO = value; }
    }

    private object _FLPADRONAFILIADO;
    [DataMember(EmitDefaultValue = false, Name = "FLPADRONAFILIADO")]
    public object FLPADRONAFILIADO
    {
        get
        {
            if (_FLPADRONAFILIADO == null) { return 0; }
            else
            {
                if (_FLPADRONAFILIADO.NoNulo())
                {
                    if (_FLPADRONAFILIADO.ToString() == "on") { return 1; }
                    else if (_FLPADRONAFILIADO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLPADRONAFILIADO = value; }
    }

    private object _FLCOMITE;
    [DataMember(EmitDefaultValue = false, Name = "FLCOMITE")]
    public object FLCOMITE
    {
        get
        {
            if (_FLCOMITE == null) { return 0; }
            else
            {
                if (_FLCOMITE.NoNulo())
                {
                    if (_FLCOMITE.ToString() == "on") { return 1; }
                    else if (_FLCOMITE.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLCOMITE = value; }
    }

    private object _FLREPRESENTANTE;
    [DataMember(EmitDefaultValue = false, Name = "FLREPRESENTANTE")]
    public object FLREPRESENTANTE
    {
        get
        {
            if (_FLREPRESENTANTE == null) { return 0; }
            else
            {
                if (_FLREPRESENTANTE.NoNulo())
                {
                    if (_FLREPRESENTANTE.ToString() == "on") { return 1; }
                    else if (_FLREPRESENTANTE.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLREPRESENTANTE = value; }
    }

    private object _FLESTADOOP;
    [DataMember(EmitDefaultValue = false, Name = "FLESTADOOP")]
    public object FLESTADOOP
    {
        get
        {
            if (_FLESTADOOP == null) { return 0; }
            else
            {
                if (_FLESTADOOP.NoNulo())
                {
                    if (_FLESTADOOP.ToString() == "on") { return 1; }
                    else if (_FLESTADOOP.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLESTADOOP = value; }
    }


    private object _FLVISIBLE;
    [DataMember(EmitDefaultValue = false, Name = "FLVISIBLE")]
    public object FLVISIBLE
    {
        get
        {
            if (_FLVISIBLE == null) { return 0; }
            else
            {
                if (_FLVISIBLE.NoNulo())
                {
                    if (_FLVISIBLE.ToString() == "on") { return 1; }
                    else if (_FLVISIBLE.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLVISIBLE = value; }
    }


    private object _FLVALIDO;
    [DataMember(EmitDefaultValue = false, Name = "FLVALIDO")]
    public object FLVALIDO
    {
        get
        {
            if (_FLVALIDO == null) { return 0; }
            else
            {
                if (_FLVALIDO.NoNulo())
                {
                    if (_FLVALIDO.ToString() == "on") { return 1; }
                    else if (_FLVALIDO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLVALIDO = value; }
    }

    private object _FLVALIDACOMITE;
    [DataMember(EmitDefaultValue = false, Name = "FLVALIDACOMITE")]
    public object FLVALIDACOMITE
    {
        get
        {
            if (_FLVALIDACOMITE == null) { return 0; }
            else
            {
                if (_FLVALIDACOMITE.NoNulo())
                {
                    if (_FLVALIDACOMITE.ToString() == "on") { return 1; }
                    else if (_FLVALIDACOMITE.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLVALIDACOMITE = value; }
    }


    private object _FLVALIDAREPRESENTANTE;
    [DataMember(EmitDefaultValue = false, Name = "FLVALIDAREPRESENTANTE")]
    public object FLVALIDAREPRESENTANTE
    {
        get
        {
            if (_FLVALIDAREPRESENTANTE == null) { return 0; }
            else
            {
                if (_FLVALIDAREPRESENTANTE.NoNulo())
                {
                    if (_FLVALIDAREPRESENTANTE.ToString() == "on") { return 1; }
                    else if (_FLVALIDAREPRESENTANTE.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLVALIDAREPRESENTANTE = value; }
    }

    private object _FLVALIDAPADRONAFILIADO;
    [DataMember(EmitDefaultValue = false, Name = "FLVALIDAPADRONAFILIADO")]
    public object FLVALIDAPADRONAFILIADO
    {
        get
        {
            if (_FLVALIDAPADRONAFILIADO == null) { return 0; }
            else
            {
                if (_FLVALIDAPADRONAFILIADO.NoNulo())
                {
                    if (_FLVALIDAPADRONAFILIADO.ToString() == "on") { return 1; }
                    else if (_FLVALIDAPADRONAFILIADO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLVALIDAPADRONAFILIADO = value; }
    }

    private object _FLCANDADO;
    [DataMember(EmitDefaultValue = false, Name = "FLCANDADO")]
    public object FLCANDADO
    {
        get
        {
            if (_FLCANDADO == null) { return 0; }
            else
            {
                if (_FLCANDADO.NoNulo())
                {
                    if (_FLCANDADO.ToString() == "on") { return 1; }
                    else if (_FLCANDADO.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLCANDADO = value; }
    }

    private object _FLPADRONELECTORAL;
    [DataMember(EmitDefaultValue = false, Name = "FLPADRONELECTORAL")]
    public object FLPADRONELECTORAL
    {
        get
        {
            if (_FLPADRONELECTORAL == null) { return 0; }
            else
            {
                if (_FLPADRONELECTORAL.NoNulo())
                {
                    if (_FLPADRONELECTORAL.ToString() == "on") { return 1; }
                    else if (_FLPADRONELECTORAL.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLPADRONELECTORAL = value; }
    }

    private object _FLAFILIADOFROM;
    [DataMember(EmitDefaultValue = false, Name = "FLAFILIADOFROM")]
    public object FLAFILIADOFROM
    {
        get
        {
            if (_FLAFILIADOFROM == null) { return 0; }
            else
            {
                if (_FLAFILIADOFROM.NoNulo())
                {
                    if (_FLAFILIADOFROM.ToString() == "on") { return 1; }
                    else if (_FLAFILIADOFROM.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLAFILIADOFROM = value; }
    }


    private object _FLCUMPLE;
    [DataMember(EmitDefaultValue = false, Name = "FLCUMPLE")]
    public object FLCUMPLE
    {
        get
        {
            if (_FLCUMPLE == null) { return 0; }
            else
            {
                if (_FLCUMPLE.NoNulo())
                {
                    if (_FLCUMPLE.ToString() == "on") { return 1; }
                    else if (_FLCUMPLE.ToString() == "1") { return 1; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        set { _FLCUMPLE = value; }
    }

    [DataMember(EmitDefaultValue = false, Name = "JSONSTRING")] public string JSONSTRING { get; set; }


    [DataMember(EmitDefaultValue = false, Name = "TXARCHIVOEXTENSION")] public string TXARCHIVOEXTENSION { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXARCHIVONOMBRE")] public string TXARCHIVONOMBRE { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXARCHIVORUTACOMPLETA")] public string TXARCHIVORUTACOMPLETA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "BLARCHIVO")] public byte[] BLARCHIVO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "FLARCHIVOTIENE")] public int FLARCHIVOTIENE { get; set; }

    private bool disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        if (disposing)
        {
          
        }
        this.disposed = true;
    }

    ~BE_BASE() { Dispose(false); }

    public BE_BASE()  {  }

}

//interface IJson
//{
//    //[DataMember(EmitDefaultValue = false, Name = "JSONSTRING")] public string JSONSTRING { get; set; }
//     string JSONSTRING { get; set; }
//}

 


public class BE_PARAMETRO_FORMATOFECHA {


    [DataMember(EmitDefaultValue = false, Name = "TXFORMATOENTRADA")] public string TXFORMATOENTRADA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXFORMATOSALIDA")] public string TXFORMATOSALIDA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "FECALCULO")] public DateTime FECALCULO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXFECHAENTRADA")] public string TXFECHAENTRADA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "FORMATOFECHACOL")] public List<BE_FORMATOFECHA> FORMATOFECHACOL { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "NUANNO")] public int NUANNO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUMES")] public int NUMES { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUDIA")] public int NUDIA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUHORA")] public int NUHORA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUMINUTO")] public int NUMINUTO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUSEGUNDO")] public int NUSEGUNDO { get; set; }
    
}
public class BE_FORMATOFECHA
{
    [DataMember(EmitDefaultValue = false, Name = "TXTIPOFORMATO")] public string TXTIPOFORMATO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "IDTIPODATO")] public int IDTIPODATO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXVALOR")] public string TXVALOR { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUCARACTERINICIAL")] public int NUCARACTERINICIAL { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUCARACTERES")] public int NUCARACTERES { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXSIGLA")] public string TXSIGLA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUORDEN")] public int NUORDEN { get; set; }

}


