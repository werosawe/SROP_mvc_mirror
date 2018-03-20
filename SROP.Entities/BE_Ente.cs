using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Ente : BE_BASE
	{

		public string Cod_Ente { get; set; }
		public string Des_Ente { get; set; }

		public string Responsable_Ente { get; set; }
		public string Cargo_Responsable { get; set; }
		public string Logo1 { get; set; }
		public string Logo2 { get; set; }

		public string Prefijo_MTD { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Ente() { Dispose(false); }

    }
