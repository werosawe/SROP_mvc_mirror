using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Roles : BE_BASE
	{
		public string Cod_Rol { get; set; }
		public string Des_Rol { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Roles() { Dispose(false); }
    }

