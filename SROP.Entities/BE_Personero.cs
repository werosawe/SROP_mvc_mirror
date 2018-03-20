using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

	[Serializable()]
	public class BE_Personero : BE_BASE
	{
		public string Cod_Proc { get; set; }
		public string Cod_DNI { get; set; }

		public List<BE_Cargo> Cargos { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Personero() { Dispose(false); }

    
}
