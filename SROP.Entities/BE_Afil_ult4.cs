using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Afil_ult4 : BE_BASE
	{

    [DataMember(EmitDefaultValue = false, Name = "DNI")] public string DNI { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApPat")] public string ApPat { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "ApMat")] public string ApMat { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Nombres")] public string Nombres { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Afil_Actual")] public string Afil_Actual { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Afil_4_anios")] public string Afil_4_anios { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "OP")] public string OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tipo")] public string Tipo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Estado")] public string Estado { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Motivo")] public string Motivo { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "observ")] public string observ { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Afil_ult4() { Dispose(false); }

    }

