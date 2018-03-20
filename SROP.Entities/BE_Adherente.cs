using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Adherente : BE_BASE
	{
        
    [DataMember(EmitDefaultValue = false, Name = "Cod_Req")] public string Cod_Req { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Firmas_Val")] public int Num_Firmas_Val { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Doc_Onpe")] public string Doc_Onpe { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Fec_Doc")] public DateTime? Fec_Doc { get; set; }
   
    [DataMember(EmitDefaultValue = false, Name = "Observ")] public string Observ { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Resol")] public string Num_Resol { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Firmas_Necesarias")] public int Num_Firmas_Necesarias { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Num_Firmas_Restantes")] public int Num_Firmas_Restantes { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Adq_Kit_2016")] public int Adq_Kit_2016 { get; set; }
		



        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Adherente() { Dispose(false); }
    }

