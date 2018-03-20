using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_Tipo : BE_BASE
{

    [DataMember(EmitDefaultValue = false, Name = "IDGRUPO")] public int IDGRUPO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "IDTIPO")] public int IDTIPO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXTIPO")] public string TXTIPO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXDESCRIPCION")] public string TXDESCRIPCION { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXVALOR")] public string TXVALOR { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXSIGLA")] public string TXSIGLA { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUORDEN")] public int NUORDEN { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "IDTIPOREF")] public int IDTIPOREF { get; set; }


    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Tipo() { Dispose(false); }

}
