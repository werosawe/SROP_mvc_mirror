using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_Partida : BE_BASE
{
    [DataMember(EmitDefaultValue = false, Name = "Cod_Exp_Mtd")] public string Cod_Exp_Mtd { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Doc_Mtd")] public string Cod_Doc_Mtd { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Id_Correl")] public int Id_Correl { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Id_Correl_Show")] public int Id_Correl_Show { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Tarea")] public string Des_Tarea { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Id_Asig_Abogado")] public int Id_Asig_Abogado { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Abogado")] public string Abogado { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Tarea")] public string Cod_Tarea { get; set; }


    [DataMember(EmitDefaultValue = false, Name = "Fec_Asig")] public DateTime? Fec_Asig { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Recep")] public DateTime? Fec_Recep { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Fin")] public DateTime? Fec_Fin { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Dias_Est")] public int Num_Dias_Est { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Observaciones")] public string Observaciones { get; set; }

    //[DataMember(EmitDefaultValue = false, Name = "Img_Simbolo_Op")] public byte[] Img_Simbolo_Op { get; set; }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Partida() { Dispose(false); }
}