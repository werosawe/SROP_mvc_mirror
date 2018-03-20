using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_TipoAsiento : BE_BASE
	{

		public string Cod_Tipo_Asiento { get; set; }
		public string Des_Tipo_Asiento { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_TipoAsiento() { Dispose(false); }
    }

