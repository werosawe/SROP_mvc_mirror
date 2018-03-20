using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_Cargos_AltasBajas : BE_BASE
	{

		//Comentario prueba

		public string ID_CODIGO { get; set; }
		public string TX_DESCRIPCION { get; set; }
    	
		public string Cod_DNI { get; set; }
		public int Cod_Correl_Repres { get; set; }
		public int Id_Orden { get; set; }
		public string Cod_Cargo { get; set; }
		public string Des_Cargo { get; set; }
		public DateTime? Fec_Carga { get; set; }
		public DateTime? Fec_Baja { get; set; }
		public string Cod_Motivo_Baja { get; set; }
		public string Des_Motivo_Baja { get; set; }
		public string tx_Observacion { get; set; }
		public string Des_Asiento_Carga { get; set; }
		public string Des_Asiento_Baja { get; set; }
		public int Num_Asiento_Carga { get; set; }
		public int Num_Asiento_Baja { get; set; }
		


        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Cargos_AltasBajas() { Dispose(false); }
    }

