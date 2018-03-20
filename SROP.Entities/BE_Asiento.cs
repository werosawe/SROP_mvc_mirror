using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Asiento : BE_BASE
	{
		public int Num_Asiento { get; set; }
		public string Asiento { get; set; }
		public DateTime? Fec_Asiento { get; set; }
		public string Observ { get; set; }
		public string Url_Asiento { get; set; }
		public string Cod_Tipo_Asiento { get; set; }
		public string Des_Tipo_Asiento { get; set; }
		
		public string Asiento_Numero { get; set; }

		public struct ret_HistCargo
		{
			public int Total_Asientos;
			public string Cargo;
			public string DNI;

			public string Nombres;
		}

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Asiento() { Dispose(false); }
    }

