using System;
using System.Data;
using System.Runtime.Serialization;

	[Serializable()]
	public class BE_DocLegales : BE_BASE
	{
        public DataTable DocLegDetalle { get; set; }
        

        public string Cod_Pri { get; set; }
		public string Cod_Sec { get; set; }
		public string Cod_Ter { get; set; }
		public string TX_Titulo { get; set; }
		public string TX_Archivo { get; set; }
		public string TX_Folder { get; set; }
		public string URL_archivo { get; set; }


   
    
		public DateTime? fec_solic { get; set; }
		public int sub_items { get; set; }

		//public DataTable DocLegDetalle { get; set; }

		public string tipo_lista { get; set; }
		public string tipo_doc { get; set; }
		public string para1 { get; set; }
		public string para2 { get; set; }
		public string para3 { get; set; }


        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_DocLegales() { Dispose(false); }
    }
