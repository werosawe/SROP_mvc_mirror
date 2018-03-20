using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Directivo : BE_BASE
	{
		
		public string Des_Tipo_OP { get; set; }
		public string Des_Estado_Inscrip { get; set; }
		public string Cod_Cargo { get; set; }
		public string Des_Cargo { get; set; }
		public string Cod_Cargo_Comun { get; set; }
		public string Des_Cargo_Comun { get; set; }
		public string Cod_Correl { get; set; }
		public string Cod_Dni { get; set; }
		public string Nombre_Completo { get; set; }
		public string ApePat_Pe { get; set; }
		public string ApeMat_Pe { get; set; }
		public string Nombre_Pe { get; set; }
		public string EsAfiliado { get; set; }
		public string Cod_Motivo_Baja { get; set; }
		public string Des_motivo { get; set; }
		public DateTime? Fec_Baja { get; set; }
		public DateTime? Fec_Carga { get; set; }
		public string Abogado_OP { get; set; }
		public int num_repres_proxfin { get; set; }
		public string Observ { get; set; }
		public int anos_vigencia_cargo { get; set; }
		public string Fec_Insc_OP { get; set; }
		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Directivo() { Dispose(false); }
    }

