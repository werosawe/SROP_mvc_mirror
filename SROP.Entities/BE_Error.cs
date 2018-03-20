using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_Error : BE_BASE
{
   [DataMember(EmitDefaultValue = false, Name = "TXERROR")] public string TXERROR { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXORIGEN")] public string TXORIGEN { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "NUSTATUSCODE")] public int NUSTATUSCODE { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "TXUSUARIO")] public string TXUSUARIO { get; set; }

  

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_Error() { Dispose(false); }

}
