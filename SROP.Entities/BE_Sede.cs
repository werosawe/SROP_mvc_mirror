using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Sede : BE_BASE
	{
		public string Cod_Ente { get; set; }
		public string Des_Ente { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Sede() { Dispose(false); }
    }
