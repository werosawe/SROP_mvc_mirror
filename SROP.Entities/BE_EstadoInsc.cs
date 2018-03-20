using System;
using System.Runtime.Serialization;

[Serializable()]
public class BE_EstadoInsc : BE_BASE
{
    [DataMember(EmitDefaultValue = false, Name = "Cod_Estado_Inscrip")] public string Cod_Estado_Inscrip { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Estado_Inscrip")] public string Des_Estado_Inscrip { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "CODTIPOMOV")] public string CODTIPOMOV { get; set; }
    
    public BE_EstadoInsc(string _CODTIPOMOV) {
        CODTIPOMOV = _CODTIPOMOV;
    }

    public  BE_EstadoInsc() { }

    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing) { }
        disposed = true;
        base.Dispose(disposing);
    }
    ~BE_EstadoInsc() { Dispose(false); }
}
