using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_HistAfil : BE_BASE
	{

		public string Accion { get; set; }
		public string Cod_DNI { get; set; }
		
		public int flg_Estado_Afil_curr { get; set; }
		public int flg_Estado_Afil_new { get; set; }
		
		public string Aspx { get; set; }
		public string Fec_Repres { get; set; }
		public string Fec_Padron_Afil { get; set; }
		public string Fec_renuncia { get; set; }
		public string Fec_renun_OP { get; set; }
		public string Fec_comite { get; set; }
	
	
		//public int UbiRegion { get; set; }
		//public int UbiProv { get; set; }
		//public int UbiDist { get; set; }


        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_HistAfil() { Dispose(false); }

    }

