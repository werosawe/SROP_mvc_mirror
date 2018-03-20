using System;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_opPDF : BE_BASE
	{	
	
		public string Id_Estado_OP { get; set; }
		public string Tipo_OP { get; set; }
		public string Siglas_Estado_Insc { get; set; }
		public int N_Page_Curr { get; set; }
		public byte[] PDF_Page { get; set; }
		public int N_Page_Tot { get; set; }
		

		public int Id_Indice { get; set; }
		public int Id_Indice_Show { get; set; }
		public string Tema_Indice { get; set; }
		public int Pagina_Indice { get; set; }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_opPDF() { Dispose(false); }

    }

