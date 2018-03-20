using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_Ambito : BE_BASE
{
    [DataMember(EmitDefaultValue = false, Name = "ID_CODIGO")] public string ID_CODIGO { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TX_DESCRIPCION")] public string TX_DESCRIPCION { get; set; }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Ambito() { Dispose(false); }
}
