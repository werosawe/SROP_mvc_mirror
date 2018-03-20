using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Persona : BE_BASE
	{

		public string Cod_Cargo { get; set; }
		public string Des_Cargo { get; set; }

		public string Cod_Dni { get; set; }
		public string ApePat { get; set; }
		public string ApeMat { get; set; }
		public string Nombre { get; set; }
		public string Sexo { get; set; }
		
		public int enPadronElec { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Persona() { Dispose(false); }
    }

