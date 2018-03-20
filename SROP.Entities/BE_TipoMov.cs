using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_TipoMov : BE_BASE
	{

		public string Cod_Tipo_Movim { get; set; }
		public string Des_Tipo_Movim { get; set; }
		public string Enableddlestado { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_TipoMov() { Dispose(false); }
    }

