using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_PadronAfil : BE_BASE
	{	
		
		public string Des_Tipo_OP { get; set; }
		public DateTime? Fec_Present { get; set; }
		public int Nro_Entrega { get; set; }
		public string URL_Padron { get; set; }
		public string Des_Estado_Inscrip { get; set; }
		public string Region { get; set; }
		public DateTime? Ult_Fec_Entrega { get; set; }
		public string Cancelatorio { get; set; }

		public string Nro_Orden { get; set; }
		public string NomArch { get; set; }
		public string Descripcion { get; set; }

		public string Partido { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_PadronAfil() { Dispose(false); }

    }

