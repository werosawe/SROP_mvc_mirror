using System;
using System.Runtime.Serialization;
	[Serializable()]
	public class BE_ConstanciaAfil : BE_BASE
	{	
		public string Fecha_Constancia { get; set; }
		public string Solicitante { get; set; }
		public int Num_Const { get; set; }

		public string Responsable_Constancia { get; set; }
		public string Cargo_Responsable_A { get; set; }
		public string Cargo_Responsable { get; set; }
		public object logo1 { get; set; }
		public object logo2 { get; set; }
		public bool EsAfiliado { get; set; }
		public bool EsCandidato { get; set; }





        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_ConstanciaAfil() { Dispose(false); }

    }
