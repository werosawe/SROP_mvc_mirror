using System;
using System.Runtime.Serialization;
	[Serializable()]
	public class BE_Constancia : BE_BASE
	{	
		public string Cod_DNI { get; set; }
		public int Num_Const { get; set; }
		
		public string Fecha { get; set; }
		public string Solicitante { get; set; }
		public string FileName { get; set; }
		public string RutaDestino { get; set; }
		public string strSP { get; set; }
		public string URL { get; set; }

		public int Emite_Constancia_Afil { get; set; }
		public string Cod_Ente_Emisor { get; set; }
		public string Cod_Ente_Constancia { get; set; }
		public string Ente { get; set; }
		public string url_ { get; set; }
		public string Des_Ente_Emisor { get; set; }
		public DateTime? fec_const { get; set; }
		public string Responsable_Constancia { get; set; }
		public string txCargo_Responsable { get; set; }
		public string txCargo_Responsable_A { get; set; }
		public string logo1 { get; set; }
		public string logo2 { get; set; }

		public struct Constancia_Afil
		{
			public int retorno;
			public string oPDF;
			public int oNum_Const;
			public string Cod_Ente_Emisor;
			public string Des_Ente_Emisor;
			public string Responsable_Constancia;
			public string Cargo_Responsable;
			public string Cargo_Responsable_A;
			public string Logo1;
			public string Logo2;
		}

		public struct Constancia_OP
		{
			public int retorno;
			public string oPDF;
			public int oNum_Const;

		}

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BE_Constancia() { Dispose(false); }

    }

