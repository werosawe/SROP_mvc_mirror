using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_EstadoAfil : BE_BASE
	{

		public int Cod_Estado { get; set; }
		public string Des_Estado { get; set; }
		public int Tipo_Renuncia { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_EstadoAfil() { Dispose(false); }
    }

