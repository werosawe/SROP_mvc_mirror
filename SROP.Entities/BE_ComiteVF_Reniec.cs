using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_ComiteVF_Reniec : BE_BASE
	{	
		public int Nro_Presen { get; set; }
		public string Cod_Dni { get; set; }
        public string Codr_Vf { get; set; }
        
        public int UbiReg { get; set; }
		public int UbiProv { get; set; }
		public int UbiDist { get; set; }
		public string Cod_Resultado_Vf { get; set; }
		public string ApePat { get; set; }
		public string ApeMat { get; set; }
		public string Nombres { get; set; }
		public string tx_Obs_RENIEC { get; set; }
		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ComiteVF_Reniec() { Dispose(false); }
    }

