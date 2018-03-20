using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_CargosOP : BE_BASE
	{
		public int ordShow { get; set; }
		public string Cod_Cargo { get; set; }
		public string Des_Cargo { get; set; }
		public string fec_estatuto { get; set; }
		public string cod_tipo_doc { get; set; }
		public int orden { get; set; }
		public int anos_vigencia { get; set; }
		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_CargosOP() { Dispose(false); }
    }

