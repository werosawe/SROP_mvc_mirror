using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_TipoCancel : BE_BASE
	{

		public string Cod_Motivo_Cancel { get; set; }
		public string Des_Motivo_Cancel { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_TipoCancel() { Dispose(false); }
    }

