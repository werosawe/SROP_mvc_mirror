using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_ComiteVF : BE_BASE
	{	
		public int Nro_Presen { get; set; }
		public DateTime? Fec_Envio_Vf { get; set; }
		public DateTime? Fec_Recep_Vf { get; set; }
		public string SubFolder { get; set; }

		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ComiteVF() { Dispose(false); }
    }

