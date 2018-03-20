using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_ResulResol : BE_BASE
	{

		public string Cod_Resultado { get; set; }
		public string Des_Resultado { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ResulResol() { Dispose(false); }
    }

