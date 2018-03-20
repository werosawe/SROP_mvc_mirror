using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_ComiteMotBaja : BE_BASE
	{

		public int Cod_Motivo { get; set; }
		public string Des_Motivo { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ComiteMotBaja() { Dispose(false); }
    }

