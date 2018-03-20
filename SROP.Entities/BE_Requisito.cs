using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Requisito : BE_BASE
	{
		
		public string Des_Tipo_OP { get; set; }
		public string Des_Req { get; set; }
		public string Cod_Req { get; set; }
      

   
		public string Wf { get; set; }
		public string Observ { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Requisito() { Dispose(false); }
    }

