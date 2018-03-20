using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_EstadoOP : BE_BASE
	{

		public string ID_CODIGO { get; set; }
		public string TX_DESCRIPCION { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_EstadoOP() { Dispose(false); }
    }

