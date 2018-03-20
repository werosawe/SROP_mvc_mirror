using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_ReqTipoOP : BE_BASE
	{

    [DataMember(EmitDefaultValue = false, Name = "Cod_Req")] public string Cod_Req { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "Des_Req")] public string Des_Req { get; set; }

  

    

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ReqTipoOP() { Dispose(false); }
    }

