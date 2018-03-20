using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_Auto : BE_BASE
	{
		public int Orden { get; set; }
		public int Cod_Auto { get; set; }
		public string Des_Doc { get; set; }
		public string File_Name { get; set; }
		//Public Property Fec_Doc As Nullable(Of Date) = Nothing
		public string Fec_Doc { get; set; }
		public string Url_Auto { get; set; }
		

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Auto() { Dispose(false); }
    }

