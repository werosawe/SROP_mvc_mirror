using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

[Serializable()]
public class BE_Cargo : BE_BASE
{

    [DataMember(EmitDefaultValue = false, Name = "Cod_Cargo")] public string Cod_Cargo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_DNI")] public string Cod_DNI { get; set; }



    [DataMember(EmitDefaultValue = false, Name = "Des_Cargo")] public string Des_Cargo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "DesMotivo")] public string DesMotivo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Carga")] public string Fec_Carga { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Baja")] public string Fec_Baja { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Motivo_Baja")] public string Cod_Motivo_Baja { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "IsFirstRowWithThisCargo")] public bool IsFirstRowWithThisCargo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "CountOfWithThisCargo")] public int CountOfWithThisCargo { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Des_Motivo_Baja")] public string Des_Motivo_Baja { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "RepresentanteCol")] public List<BE_Representantes> RepresentanteCol { get; set; }

    public BE_Cargo() { }
    public BE_Cargo(string _cod_Cargo, string _des_Cargo, string _des_Motivo, string _fec_carga, string _fec_baja, string _cod_motivo_baja)
    {
        Cod_Cargo = _cod_Cargo;
        Des_Cargo = _des_Cargo;
        DesMotivo = _des_Motivo;
        Fec_Carga = _fec_carga;
        Fec_Baja = _fec_baja;
        Cod_Motivo_Baja = _cod_motivo_baja;
    }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Cargo() { Dispose(false); }
}

