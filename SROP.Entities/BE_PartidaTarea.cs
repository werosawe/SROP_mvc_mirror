using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_PartidaTarea : BE_BASE
	{

		public string Cod_Tarea { get; set; }
		public string Des_Tarea { get; set; }

		public string Cod_Tipo_Doc { get; set; }
		public string Des_Tipo_Doc { get; set; }

		public string Cod_Resultado { get; set; }
		public string Des_Resultado { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_PartidaTarea() { Dispose(false); }
    }

