using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

[Serializable()]
public class BE_BusquedaOP : BE_BASE
{
    [DataMember(EmitDefaultValue = false, Name = "ListaDirectivos")] public List<BE_Representantes> ListaDirectivos { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Perfil")] public string Cod_Perfil { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Ente")] public string Cod_Ente { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "SoloSedesReg")] public int SoloSedesReg { get; set; }

    public struct FecEstado
    {
        public DateTime? FecIni;
        public DateTime? FecFin;
    }

    [text(0, 0, "Fecha inicial")] [DataMember(EmitDefaultValue = false, Name = "FEINICIAL")] public DateTime? FEINICIAL { get; set; }
    [text(0, 0, "Fecha final")] [DataMember(EmitDefaultValue = false, Name = "FEFINAL")] public DateTime? FEFINAL { get; set; }
      

    
   
    [DataMember(EmitDefaultValue = false, Name = "Des_Tipo_OP")] public string Des_Tipo_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ID_EstadoOP")] public string ID_EstadoOP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ID_Asistente")] public string ID_Asistente { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Estado_Insc")] public DateTime? Fec_Estado_Insc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Estado_Inscrip")] public string Des_Estado_Inscrip { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Estado_OP")] public string Estado_OP { get; set; }


   
  


    [DataMember(EmitDefaultValue = false, Name = "Region")] public string Region { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Provincia")] public string Provincia { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Distrito")] public string Distrito { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Arc")] public string Cod_Arc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Tomo_Legajo")] public string Num_Tomo_Legajo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Tomo_Planillon")] public string Num_Tomo_Planillon { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Ubic_Legajo")] public string Ubic_Legajo { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "UbiRegion")] public int UbiRegion { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "UbiProvincia")] public int UbiProvincia { get; set; }
    //[DataMember(EmitDefaultValue = false, Name = "UbiDistrito")] public int UbiDistrito { get; set; }
  
    [DataMember(EmitDefaultValue = false, Name = "DomicilioLegal_OP")] public string DomicilioLegal_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Telefono01_OP")] public string Telefono01_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Telefono02_OP")] public string Telefono02_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Ubigeo_Concat")] public string Ubigeo_Concat { get; set; }
                                                                                                                                                
    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_BusquedaOP() { Dispose(false); }
}

