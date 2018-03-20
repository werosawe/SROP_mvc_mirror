using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Archivo : BE_BASE
	{

   

    [DataMember(EmitDefaultValue = false, Name = "Des_Tipo_OP")] public string Des_Tipo_OP { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Solic")] public DateTime? Fec_Solic { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Estado_Inscrip")] public string Des_Estado_Inscrip { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Estado")] public DateTime? Fec_Estado { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Region")] public string Region { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Provincia")] public string Provincia { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Distrito")] public string Distrito { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Tx_Ubic_Arc")] public string Tx_Ubic_Arc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Cod_Arc")] public int Cod_Arc { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Tom_Leg")] public int Num_Tom_Leg { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Tom_Pla")] public int Num_Tom_Pla { get; set; }
		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Archivo() { Dispose(false); }
    }
