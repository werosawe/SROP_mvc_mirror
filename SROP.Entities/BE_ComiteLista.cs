using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_ComiteLista : BE_BASE
	{
		public int Orden { get; set; }
	
	
		public int Num_Afil_Val { get; set; }
		public string Fec_Carga { get; set; }
		public string Region { get; set; }
		public string Provincia { get; set; }
		public string Distrito { get; set; }
		//public int UbiRegion { get; set; }
		//public int UbiProv { get; set; }
		//public int UbiDist { get; set; }
		
		public int Nro_Entrega { get; set; }
		public string Dir_Comite { get; set; }
		public int Num_Comites_Dist { get; set; }
		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ComiteLista() { Dispose(false); }
    }

