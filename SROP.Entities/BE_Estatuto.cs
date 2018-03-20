using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_Estatuto : BE_BASE
{
    [DataMember(EmitDefaultValue = false, Name = "Orden")] public int Orden { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "OrdenShow")] public int OrdenShow { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Doc")] public string Des_Doc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "File_Name")] public string File_Name { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Doc")] public DateTime? Fec_Doc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Tipo_Doc")] public string Des_Tipo_Doc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Observ")] public string Observ { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Url_Estatuto_OP")] public string Url_Estatuto_OP { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "Anos_Vigencia_Cargo")] public int Anos_Vigencia_Cargo { get; set; }

    public BE_Estatuto(){}

    public BE_Estatuto(int _Cod_OP) { Cod_OP = _Cod_OP; }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Estatuto() { Dispose(false); }
}

