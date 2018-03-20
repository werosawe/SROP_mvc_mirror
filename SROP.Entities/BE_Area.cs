using System;
using System.Runtime.Serialization;


	[Serializable()]
	public class BE_Area : BE_BASE
	{

		public string Cod_Area { get; set; }
		public string Des_Area { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Area() { Dispose(false); }
    }

