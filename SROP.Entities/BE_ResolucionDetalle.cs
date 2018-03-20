using System;
using System.Runtime.Serialization;

	public class BE_ResolucionDetalle:BE_BASE
	{	
		public int Orden { get; set; }

		public string LabelNroResol { get; set; }
		public string NroResol { get; set; }

		public string LabelFechaResol { get; set; }
		public string FechaResol { get; set; }

		public string LabelResulResol { get; set; }
		public string ResultadoResol { get; set; }

		public string Url_Resolucion { get; set; }

		public string Cod_Tipo_Resol { get; set; }
		public string Des_Tipo_Resol { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ResolucionDetalle() { Dispose(false); }

    }

