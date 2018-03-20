using System;
using System.Data;
using System.Runtime.Serialization;

[Serializable()]
public class BE_Representantes : BE_BASE
{

    [DataMember(EmitDefaultValue = false, Name = "DNI")] public string DNI { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApePat_OP")] public string ApePat_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApeMat_OP")] public string ApeMat_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Nombres_OP")] public string Nombres_OP { get; set; }


    [DataMember(EmitDefaultValue = false, Name = "TXESTADOINSCRIPCION")] public string TXESTADOINSCRIPCION { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "COD_CORRELATIVO")] public string COD_CORRELATIVO { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "DES_MOTIVO")] public string DES_MOTIVO { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "TXOBSERVACION")] public string TXOBSERVACION { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "FECARGA")] public DateTime? FECARGA { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "FEBAJA")] public DateTime? FEBAJA { get; set; }

    //[DataMember(EmitDefaultValue = false, Name = "Fec_inscripcion")] public DateTime? Fec_inscripcion { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApePat_PE")] public string ApePat_PE { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApeMat_PE")] public string ApeMat_PE { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Nombres_PE")] public string Nombres_PE { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Nombre_Completo")] public string Nombre_Completo { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Cod_Cargo")] public string Cod_Cargo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Cargo")] public string Des_Cargo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Cargo_Comun")] public string Cod_Cargo_Comun { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Cargo_Comun")] public string Des_Cargo_Comun { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Motivo_Baja")] public string Cod_Motivo_Baja { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "EsAfiliado")] public bool EsAfiliado { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Orden_Cargo")] public int Orden_Cargo { get; set; }

    //public DataTable Representantes { get; set; }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Representantes() { Dispose(false); }
}

