using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_ComiteEntrega : BE_BASE
	{
		public int Nro_Entrega { get; set; }
		public int Afil_Val { get; set; }
		public int Afil_Present { get; set; }
		
		public DateTime? Fec_Envio_Reniec { get; set; }
		public DateTime? Fec_From_Reniec { get; set; }
		public DateTime? Fec_Carga { get; set; }
		public string Observ { get; set; }
		//public int UbiRegion { get; set; }
		//public int UbiProvincia { get; set; }
		//public int UbiDistrito { get; set; }
		public string Fec_Solic { get; set; }
		public int CargaFin { get; set; }
		public string TipoCargaFin { get; set; }

		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ComiteEntrega() { Dispose(false); }
    }

